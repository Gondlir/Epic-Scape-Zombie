using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeShoot : MonoBehaviour {

    public static KeyCode keyCodeShoot = KeyCode.X;
    public static TypeShoot instance;

    private void Awake()
    {
        instance = this;
    }

    public void Manual()
    {
        if (Input.GetKeyDown(keyCodeShoot))
        {
            Debug.Log("Shoot Manual");
            --WeaponManager.instance.AmmounitionCurrent;
        }
    }

    public void Automatic()
    {
        if (Input.GetKeyDown(keyCodeShoot))
        {
            InvokeRepeating("AutomaticAsyc", 0, .3f);
        }
        else if (Input.GetKeyUp(keyCodeShoot))
        {
            CancelInvoke("AutomaticAsyc");
        }
    }

    private void AutomaticAsyc()
    {
        Debug.Log("Shoot Automatic");
        --WeaponManager.instance.AmmounitionCurrent;
        if(WeaponManager.instance.AmmounitionCurrent < 1)
            CancelInvoke("AutomaticAsyc");
    }
}
public enum TypeShootFlag { Manual, Automatic }