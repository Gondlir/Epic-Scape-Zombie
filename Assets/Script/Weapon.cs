using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Assets/Weapon")]
public class Weapon : MonoBehaviour {

    public int damage;
    public int AmmounitionMax;
    public TypeShoot typeShoot;
    

    public void Shoot()
    {
        KeyCode keyCodeShoot = KeyCode.X;
        switch (typeShoot)
        {
            case TypeShoot.Manual:
                if (Input.GetKeyDown(keyCodeShoot))
                {

                }
                break;
            case TypeShoot.Automatic:
                if(Input.GetKey(keyCodeShoot))
                {

                }
                break;
            default:
                break;
        }
    }
}

public enum TypeShoot { Manual, Automatic}