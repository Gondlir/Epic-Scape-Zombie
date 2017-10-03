using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Inventory/Weapon", order = 1)]
public class Weapon : ScriptableObject {

    public int damage;
    public int AmmounitionMax;

    public TypeShootFlag typeShootFlag;


    public void Shoot()
    {
        switch (typeShootFlag)
        {
            case TypeShootFlag.Manual:
                TypeShoot.instance.Manual();
                break;
            case TypeShootFlag.Automatic:
                TypeShoot.instance.Automatic();
                break;
            default:
                Debug.LogWarning("Not Defined Shoot");
                break;
        }
    }
}