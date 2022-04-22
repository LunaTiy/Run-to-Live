using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausedMenu;
    [SerializeField] private GameObject _playingMenu;

    private Animator _pausedMenuAnimator;
    private Animator _playingMenuAnimator;

	private void Start()
	{
		_pausedMenuAnimator = _pausedMenu.GetComponent<Animator>();
		_playingMenuAnimator = _playingMenu.GetComponent<Animator>();
	}

	public void OpenGameMenu()
	{
        _pausedMenuAnimator.SetTrigger("Display");
		_playingMenuAnimator.SetTrigger("Hide");
	}

    public void CloseGameMenu()
	{
        _pausedMenuAnimator.SetTrigger("Hide");
		_playingMenuAnimator.SetTrigger("Display");
	}
}
