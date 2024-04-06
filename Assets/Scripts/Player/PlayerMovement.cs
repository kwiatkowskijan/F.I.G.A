using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;

    private float _hInput, _vInput;
    public float moveSpeed;

    void Start()
    {
        GetReferences();

    }

    void Update()
    {
        GetInputs();

    }

    void FixedUpdate()
    {
        Walk();
    }

    private void Walk()
    {
        Vector3 movement = new Vector3(_hInput, 0.0f, _vInput) * moveSpeed * Time.fixedDeltaTime;

        _rb.MovePosition(transform.position + transform.TransformDirection(movement));
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
