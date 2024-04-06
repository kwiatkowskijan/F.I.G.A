using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerAimController : MonoBehaviour
{
    public Cinemachine.AxisState xAxis, yAxis;
    [SerializeField] Transform camFollowPos;
    [HideInInspector] public CinemachineVirtualCamera _cam;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float zoomFov;
    [SerializeField] private float normalFov;
    [SerializeField] private float sensitivity;
    public bool isAiming = false;

    private PlayerMovement _playerMovement;

    private Coroutine zoomCoroutine;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _cam = GetComponentInChildren<CinemachineVirtualCamera>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);

        if (Input.GetMouseButtonDown(1))
        {
            if (zoomCoroutine != null)
                StopCoroutine(zoomCoroutine);
            zoomCoroutine = StartCoroutine(ChangeZoom(zoomFov));
            _playerMovement.moveSpeed = _playerMovement.moveSpeed / 2;
            isAiming = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (zoomCoroutine != null)
                StopCoroutine(zoomCoroutine);
            zoomCoroutine = StartCoroutine(ChangeZoom(normalFov));
            _playerMovement.moveSpeed = _playerMovement.moveSpeed * 2;
            isAiming = false;
        }
    }

    private void LateUpdate()
    {
        camFollowPos.localEulerAngles = new Vector3(yAxis.Value, camFollowPos.localEulerAngles.y, camFollowPos.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis.Value, transform.eulerAngles.z);
    }

    IEnumerator ChangeZoom(float targetFov)
    {
        float currentZoom = _cam.m_Lens.FieldOfView;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * zoomSpeed;
            _cam.m_Lens.FieldOfView = Mathf.Lerp(currentZoom, targetFov, t);
            yield return null;
        }
    }
}
