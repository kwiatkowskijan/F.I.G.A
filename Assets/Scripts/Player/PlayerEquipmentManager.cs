using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentManager : MonoBehaviour
{
    private PlayerInventory _inventory;
    [SerializeField] private Transform weaponHolder;
    void Start()
    {
        GetReferences();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _inventory.GetItem(0);
        }
    }

    private void GetReferences()
    {
        _inventory = GetComponent<PlayerInventory>();
    }
}
