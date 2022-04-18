using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureGroundScroller : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;

	private MeshRenderer _renderer;
	private float _offset;

	private void Start()
	{
		_renderer = GetComponent<MeshRenderer>();
	}

	private void Update()
	{
		_offset += Time.deltaTime * _speed;

		if (_offset >= 1) _offset -= 1;

		_renderer.material.mainTextureOffset = new Vector2(0, _offset);
	}
}
