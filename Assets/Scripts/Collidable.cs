using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collidable : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 20f;
    [SerializeField] private float _timeAmount = 1.5f;

	private GameManager _gameManager;

	private void Start()
	{
		_gameManager = FindObjectOfType<GameManager>();
	}

	private void Update()
	{
		transform.Translate(0, 0, -_moveSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.TryGetComponent<Player>(out Player player))
		{
			_gameManager.AdjustTime(_timeAmount);
			Destroy(gameObject);
		}
	}
}
