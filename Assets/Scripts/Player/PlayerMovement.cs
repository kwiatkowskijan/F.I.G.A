using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;

    private float _hInput, _vInput;
    public float moveSpeed;
    private bool _canDash = true;
    private bool _isDashing = false;
    [SerializeField] private float _dashForce;
    [SerializeField] private float _dashingTime;
    [SerializeField] private float _dashingCooldown;

    void Start()
    {
        GetReferences();
    }

    void Update()
    {
        GetInputs();

        if (_canDash && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash());
        }

    }

    void FixedUpdate()
    {
        Walk();
    }

    private void Walk()
    {
        if (!_isDashing)
        {
            Vector3 movement = new Vector3(_hInput, 0.0f, _vInput) * moveSpeed * Time.fixedDeltaTime;
            _rb.MovePosition(transform.position + transform.TransformDirection(movement));
        }
    }

    private IEnumerator Dash()
    {
        _canDash = false;
        _isDashing = true;

        Vector3 dashDirection = new Vector3(_hInput, 0.0f, _vInput);
        _rb.velocity = dashDirection * _dashForce;

        yield return new WaitForSeconds(_dashingTime);

        _rb.velocity = Vector3.zero;
        _isDashing = false;

        yield return new WaitForSeconds(_dashingCooldown);
        _canDash = true;
    }


    private void GetInputs()
    {
        _hInput = Input.GetAxis("Horizontal");
        _vInput = Input.GetAxis("Vertical");
    }
    private void GetReferences()
    {
        _rb = GetComponent<Rigidbody>();
    }
}
