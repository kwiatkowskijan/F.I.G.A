using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] private float _shootRange;
    private float _lastShootTime = 0;
    private PlayerEquipmentManager _equipmentManager;
    private PlayerInventory _inventory;

    private void Start()
    {
        GetReferences();
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
            Debug.DrawRay(ray.origin, ray.direction * _shootRange, Color.red, 0.1f);
            Debug.Log(hit.transform.name);
        }
    }

    private void Shoot()
    {
        Weapon currentWeapon = _inventory.GetItem(_equipmentManager.currentWeapon);

        if(Time.time > _lastShootTime + currentWeapon.fireRate)
        {
            _lastShootTime = Time.time;
            RaycastShoot();
        }
    }

    private void GetFireRate(Weapon weapon)
    {
        
    }

    private void GetReferences()
    {
        _camera = GetComponentInChildren<Camera>();
        _equipmentManager = GetComponent<PlayerEquipmentManager>();
        _inventory = GetComponent<PlayerInventory>();
    }
}
