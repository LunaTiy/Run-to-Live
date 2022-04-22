using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateControl : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent _startedGame;
    [SerializeField] private UnityEvent _pausedGame;
    [SerializeField] private UnityEvent _continuedGame;

    [Header("References")]
    [SerializeField] private Player _player;

    private GameManager _gameManager;
    private Spawner _spawner;

    private bool _isStartGame;
    private bool _isPlaying;

    private void Start()
	{
        _gameManager = GetComponent<GameManager>();
        _spawner = GetComponent<Spawner>();

        DisableScripts();
	}

	private void Update()
	{
		if(Input.GetButtonDown("Cancel") && _isStartGame)
		{
            if (_isPlaying) PausedGame();
            else ContinueGame();
		}
	}

	public void StartGame()
	{
        _startedGame?.Invoke();

        EnableScripts();
        DestroyCollidableObjects();

        _isStartGame = true;
        _isPlaying = true;
	}

    public void PausedGame()
	{
        _pausedGame?.Invoke();

        DisableScripts();

        _isPlaying = false;
	}

    public void ContinueGame()
	{
        if (_isStartGame)
        {
            _continuedGame?.Invoke();

            EnableScripts();

            _isPlaying = true;
        }
	}

    public void ExitGame()
	{
        Application.Quit();
	}

    public void GameOver()
	{
        PausedGame();
        _isStartGame = false;
	}

    private void EnableScripts()
    {
        _gameManager.enabled = true;
        _spawner.enabled = true;
        _player.enabled = true;

        Collidable[] objects = FindObjectsOfType<Collidable>();

        foreach (var obj in objects)
            obj.enabled = true;
    }

    private void DisableScripts()
	{
        _gameManager.enabled = false;
        _spawner.enabled = false;
        _player.enabled = false;

        Collidable[] objects = FindObjectsOfType<Collidable>();

        foreach (var obj in objects)
            obj.enabled = false;
    }

    private void DestroyCollidableObjects()
	{
        Collidable[] objects = FindObjectsOfType<Collidable>();

        foreach (var obj in objects)
            Destroy(obj.gameObject);
	}
}
