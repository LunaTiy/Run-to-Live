using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	[SerializeField] private UpdateUIEvent EstablishedLifeTime;

	[SerializeField] private Text _elapsedTime;
	public float _gameTime = 10f;

	private float _totalTimeElapsed;
	private bool _isGameOver;

	private void Start()
	{
		EstablishedLifeTime?.Invoke(_gameTime);
	}

	private void Update()
	{
		if (_isGameOver) return;

		_totalTimeElapsed += Time.deltaTime;
		_gameTime -= Time.deltaTime;

		if (_gameTime <= 0) _isGameOver = true;

		UpdateUI();
	}

	public void AdjustTime(float amount)
	{
		_gameTime += amount;

		if (amount < 0) SpeedWorldDown();
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
		_elapsedTime.text = $"Elapsed time: {_totalTimeElapsed:F1}";
	}
}

[System.Serializable]
class UpdateUIEvent : UnityEvent<float> { }
