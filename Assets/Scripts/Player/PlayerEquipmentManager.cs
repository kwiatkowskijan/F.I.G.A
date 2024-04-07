using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class PlayerEquipmentManager : MonoBehaviour
{
    private PlayerInventory _inventory;
    private PlayerShooting _shooting;
    private HUD HUD;

    [SerializeField] private Transform weaponHolder;
    [SerializeField] private GameObject currentWeaponObject = null;
    [SerializeField] Weapon defaultWeapon;
    [SerializeField] Weapon defaultWeapon2;
    public Transform currentWeaponBarrell;
    
    

    public int currentWeapon = 0;

    void Start()
    {
        GetReferences();
        InitVariables();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentWeapon != 0)
        {
            UnequipWeapon(currentWeaponObject);
            EquipWeapon(_inventory.GetItem(0));
            currentWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && currentWeapon != 1)
        {
            UnequipWeapon(currentWeaponObject);
            EquipWeapon(_inventory.GetItem(1)); 
            currentWeapon = 1;
        }
    }

    private void EquipWeapon(Weapon weapon)
    {
        currentWeapon = weapon.eqSlot;
        HUD.UpdateWeaponName(weapon.name);
        _shooting._currentWeaponAmmo = weapon.ammo;
        _shooting._currenWeaponAmmoStorage = weapon.storageAmmo;
        _shooting._currentWeaponMaxAmmo = weapon.ammo;
        _shooting._currenWeaponMaxAmmoStorage = weapon.storageAmmo;

        GameObject newWeaponInstance = Instantiate(weapon.prefab, weaponHolder);
        currentWeaponObject = newWeaponInstance;
        
        currentWeaponBarrell = currentWeaponObject.transform.GetChild(1);
        GameObject shootingParticless = Instantiate(weapon.shootingParticles, currentWeaponBarrell);
    }

    private void UnequipWeapon(GameObject weapon)
    {
        Destroy(weapon);
    }

    private void GetReferences()
    {
        _inventory = GetComponent<PlayerInventory>();
        _shooting = GetComponent<PlayerShooting>();
        HUD = GetComponent<HUD>();
    }
    private void InitVariables()
    {
        _inventory.AddItem(defaultWeapon);
        _inventory.AddItem(defaultWeapon2);
        EquipWeapon(_inventory.GetItem(0));
    }
}
