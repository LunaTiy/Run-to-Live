using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraState : MonoBehaviour
{
    private Animator _animator;

	private void Start()
	{
		_animator = GetComponent<Animator>();
	}

	public void OnPauseCameraPosition()
	{
		_animator.SetTrigger("Pause");
	}

	public void OnPlayCameraPosition()
	{
		_animator.SetTrigger("Play");
	}
}
