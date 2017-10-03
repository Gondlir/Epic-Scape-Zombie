using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    [SerializeField] private Transform lookArm;

    public Weapon Weapon { get; set; }

    public int AmmounitionMax { get; set; }
    public int AmmounitionCurrent { get; set; }

    public void Shoot()
    {
        if (AmmounitionCurrent == 0)
        {
            Debug.Log("Not Ammounition");
            return;
        }
        Weapon.Shoot();
        --AmmounitionCurrent;
        HUDManager.instance.UpdateArmmount();
        Debug.Log("Shoot");
    }
}
