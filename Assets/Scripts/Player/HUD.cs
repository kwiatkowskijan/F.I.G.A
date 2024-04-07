using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private WeaponUI weaponUI;
    [SerializeField] private InventoryUI inventoryUI; 

    public void UpdateWeaponName(string weaponName)
    {
        weaponUI.weaponName.SetText(weaponName);
    }

    public void UpdateWeaponAmmo(int ammo)
    {
        weaponUI.currentAmmo.SetText(ammo.ToString());
    }

    public void UpdateWeaponAmmoStorage(int storage)
    {
        weaponUI.currentAmmoInStorage.SetText(storage.ToString());
    }
}
