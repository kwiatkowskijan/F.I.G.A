using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] private float _shootRange;
    [SerializeField] private float _fireRate;
    private float _lastShootTime = 0;

    private void Start()
    {
        _camera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void RaycastShoot()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, _shootRange))
        {
            Debug.Log(hit.transform.name);
        }

    }

    private void Shoot()
    {
        if(Time.time > _lastShootTime + _fireRate)
        {
            _lastShootTime = Time.time;
            RaycastShoot();
        }
    }
}
