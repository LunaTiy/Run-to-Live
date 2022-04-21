using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _powerupPrefab;
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private float _spawnCycle = 0.5f;
	[SerializeField] private Transform _groundTransform;

    private float _elapsedTime;
	private bool _spawnPowerup = true;
	private float _bounds;

	private void Start()
	{
		_bounds = _groundTransform.localScale.x / 2 - 2;
	}

	private void Update()
	{
		_elapsedTime += Time.deltaTime;

		if (_elapsedTime < _spawnCycle)
			return;

		GenerateObject();
	}

	private void GenerateObject()
	{
		GameObject newObject = null;

		if (_spawnPowerup)
			newObject = Instantiate(_powerupPrefab);
		else
			newObject = Instantiate(_obstaclePrefab);

		Vector3 spawnPosition = newObject.transform.position;
		spawnPosition.x = Random.Range(-_bounds, _bounds);
		newObject.transform.position = spawnPosition;

		_elapsedTime = 0f;
		_spawnPowerup = !_spawnPowerup;
	}
}
