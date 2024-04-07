using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] private float _shootRange;
    [SerializeField] private GameBehaviour gameBehaviour;
    private float _lastShootTime = 0;
    private PlayerEquipmentManager _equipmentManager;
    private PlayerInventory _inventory;
    private HUD hud;
    private EnemyStats enemyStats;
    private Weapon currentWeapon;

    public int _currentWeaponAmmo;
    public int _currenWeaponAmmoStorage;

    public int _currentWeaponMaxAmmo;
    public int _currenWeaponMaxAmmoStorage;

    private bool _canShoot = true;

    [SerializeField] private LayerMask _layerMask;

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

        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        CheckAmmo();
        UpdateAmmo(_currentWeaponAmmo, _currenWeaponAmmoStorage);

        currentWeapon = _inventory.GetItem(_equipmentManager.currentWeapon);

        Debug.Log(currentWeapon.name);
    }

    private void RaycastShoot()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, currentWeapon.range, _layerMask))
        {
            Debug.DrawRay(ray.origin, ray.direction * _shootRange, Color.red, 0.1f);
            Debug.Log(hit.transform.name);

            EnemyStats hitEnemy = hit.transform.GetComponent<EnemyStats>();

            if (hitEnemy != null && gameBehaviour._currentEnemies.Contains(hitEnemy))
            {
                hitEnemy.TakeDamage(currentWeapon.damage);
            }
        }
    }

    private void Shoot()
    {
        if(_canShoot)
        {
            

            if (Time.time > _lastShootTime + currentWeapon.fireRate)
            {
                _lastShootTime = Time.time;
                UseAmmo(currentWeapon);
                RaycastShoot();
            }
        }
    }

    private void UseAmmo(Weapon weapon)
    {
        _currentWeaponAmmo -= 1;
    }

    private void CheckAmmo()
    {
        if (_currentWeaponAmmo <= 0)
            _canShoot = false;
        else
            _canShoot = true;
    }

    private void Reload()
    {
        _currenWeaponAmmoStorage -= _currentWeaponMaxAmmo - _currentWeaponAmmo;
        _currentWeaponAmmo = _currentWeaponMaxAmmo;
    }

    private void UpdateAmmo(int currentAmmo, int currentAmmoStorage)
    {
        hud.UpdateWeaponAmmo(currentAmmo);
        hud.UpdateWeaponAmmoStorage(currentAmmoStorage);
    }

    private void GetReferences()
    {
        _camera = GetComponentInChildren<Camera>();
        _equipmentManager = GetComponent<PlayerEquipmentManager>();
        _inventory = GetComponent<PlayerInventory>();
        hud = GetComponent<HUD>();
        enemyStats = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyStats>();
    }
}
