using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentManager : MonoBehaviour
{
    private PlayerInventory _inventory;

    [SerializeField] private Transform weaponHolder;
    [SerializeField] private GameObject currentWeaponObject = null;
    [SerializeField] Weapon defaultWeapon;

    public int currentWeapon = 0;

    void Start()
    {
        GetReferences();
        InitVariables();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UnequipWeapon(currentWeaponObject);
            EquipWeapon(_inventory.GetItem(0));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UnequipWeapon(currentWeaponObject);
            EquipWeapon(_inventory.GetItem(1)); 
        }
    }

    private void EquipWeapon(Weapon weapon)
    {
        currentWeapon = weapon.eqSlot;
        GameObject newWeaponInstance = Instantiate(weapon.prefab, weaponHolder);
        currentWeaponObject = newWeaponInstance;
    }

    private void UnequipWeapon(GameObject weapon)
    {
        Destroy(weapon);
    }

    private void GetReferences()
    {
        _inventory = GetComponent<PlayerInventory>();
    }
    private void InitVariables()
    {
        _inventory.AddItem(defaultWeapon);
        EquipWeapon(_inventory.GetItem(0));
    }
}
