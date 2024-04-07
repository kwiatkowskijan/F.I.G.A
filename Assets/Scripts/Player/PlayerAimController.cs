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
        float mouseX = Input.GetAxis("Mouse X") * sensitivity; // Dodaj czu³oœæ do ruchu myszy w osi X
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity; // Dodaj czu³oœæ do ruchu myszy w osi Y

        mouseX *= Mathf.Sign(Input.GetAxis("Mouse X")); // Zachowaj znak ruchu myszy w osi X
        mouseY *= Mathf.Sign(Input.GetAxis("Mouse Y")); // Zachowaj znak ruchu myszy w osi Y

        xAxis.Update(Time.deltaTime * mouseX); // Zaktualizuj wartoœæ osi X
        yAxis.Update(Time.deltaTime * mouseY); // Zaktualizuj wartoœæ osi Y

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
