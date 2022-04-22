using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	[Header("UI events")]
	[SerializeField] private UpdateImageFillEvent UpdatedLifeTime;
	[SerializeField] private UpdateText UpdatedTotalTimeElapsed;

	[Header("Events")]
	[SerializeField] private UnityEvent _lossedGame;

	[Header("Properties")]
	[SerializeField] private float _gameTime = 10f;

	private float _currentLifeTime;
	private float _totalTimeElapsed;
	private bool _isGameOver;

	private void Start()
	{
		_currentLifeTime = _gameTime;
	}

	private void Update()
	{
		if (_isGameOver)
			return;

		_totalTimeElapsed += Time.deltaTime;
		_currentLifeTime -= Time.deltaTime;

		if (_currentLifeTime <= 0)
		{
			_lossedGame?.Invoke();
			_isGameOver = true;
		}

		UpdateUI();
	}

	public void AdjustTime(float amount)
	{
		_currentLifeTime += amount;

		if (_currentLifeTime > _gameTime) _currentLifeTime = _gameTime;

		if (amount < 0) SpeedWorldDown();
	}

	public void ResetTime()
	{
		_currentLifeTime = _gameTime;
		_totalTimeElapsed = 0f;
		_isGameOver = false;
	}

	private void SpeedWorldDown()
	{
		CancelInvoke("SpeedWorldUp");

		Time.timeScale = 0.5f;
		Invoke("SpeedWorldUp", 1f);
	}

	private void SpeedWorldUp()
	{
		Time.timeScale = 1f;
	}

	private void UpdateUI()
	{
		UpdatedLifeTime?.Invoke(_currentLifeTime, _gameTime);
		UpdatedTotalTimeElapsed?.Invoke(_totalTimeElapsed);
	}
}

[System.Serializable]
class UpdateImageFillEvent : UnityEvent<float, float> { }

[System.Serializable]
class UpdateText : UnityEvent<float> { }
