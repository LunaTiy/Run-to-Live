using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private UpdateImageFillEvent CooldownPhase;

    [Header("References")]
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Material _normalMaterial;
    [SerializeField] private Material _phasedMaterial;

    [Header("Gameplay")]
    [SerializeField] private Transform _groundTransform;
    [SerializeField] private float _strafeSpeed = 4f;
    [SerializeField] private float _phaseCooldown = 2f;
    [SerializeField] private float _timeInPhase = 2f;

    private SkinnedMeshRenderer _mesh;
    private Collider _collision;
    private bool _canPhase = true;
    private float _bounds;

    private void Start()
	{
        _mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        _collision = GetComponent<Collider>();

        _bounds = _groundTransform.localScale.x / 2 - 2;
	}

	private void Update()
	{
        Movement();
        EnterToPhase();
	}

    private void Movement()
	{
		float mX = Input.GetAxis("Horizontal");
		Vector3 targetPosition = new Vector3(mX + transform.position.x, transform.position.y, transform.position.z);

		targetPosition.x = Mathf.Clamp(targetPosition.x, -_bounds, _bounds);

		transform.position = Vector3.MoveTowards(transform.position, targetPosition, _strafeSpeed * Time.deltaTime);
	}

    private void EnterToPhase()
	{
        if(Input.GetButtonDown("Jump") && _canPhase)
		{
            _mesh.material = _phasedMaterial;
            _collision.enabled = false;
            _canPhase = false;
            CooldownPhase?.Invoke(0f, 1f);
            Invoke("ExitFromPhase", _timeInPhase);
		}
	}

    private void ExitFromPhase()
	{
        _mesh.material = _normalMaterial;
        _collision.enabled = true;
        _canPhase = true;
        Invoke("PhaseRecharge", _phaseCooldown);
	}

    private void PhaseRecharge()
	{
        _canPhase = true;
        CooldownPhase?.Invoke(1f, 1f);
	}
}
