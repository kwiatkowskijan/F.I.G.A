using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private WeaponUI weaponUI;

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
