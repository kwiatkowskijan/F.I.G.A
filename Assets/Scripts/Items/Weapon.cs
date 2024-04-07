using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class Weapon : Item
{
    public int magCount;
    public int damage;
    public int range;
    public float fireRate;
    public int eqSlot;
    public int ammo;
    public int storageAmmo;
    public GameObject prefab;
    public GameObject shootingParticles;
    public Transform muzzle;
}
