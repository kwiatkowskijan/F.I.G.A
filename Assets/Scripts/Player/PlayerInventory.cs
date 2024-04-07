using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // 0 - 9
    public Weapon[] weapons;

    private void Start()
    {
        InitVariables();
    }

    public void AddItem(Weapon newItem)
    {
        weapons[(int)newItem.eqSlot] = newItem;
        
    }

    private void RemoveItem(int index)
    {
        weapons[index] = null;
    }

    public Weapon GetItem(int index)
    {
        return weapons[index];
    }

    private void InitVariables()
    {
        weapons = new Weapon[10];
    }
}
