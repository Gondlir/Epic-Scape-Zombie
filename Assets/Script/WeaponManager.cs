using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    [SerializeField] private Transform lookArm;

    [SerializeField] private int currentAmmountion;

    public Weapon Weapon;

    public int AmmounitionMax { get; set; }
    public int AmmounitionCurrent
    {
        get { return currentAmmountion; }
        set
        {
            currentAmmountion = value;
            HUDManager.instance.UpdateArmmount();
        } }

    public static WeaponManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AmmounitionMax = Weapon.AmmounitionMax;
        currentAmmountion = Weapon.AmmounitionMax;
        HUDManager.instance.UpdateArmmount();
        
    }

    public void Shoot()
    {
        if (currentAmmountion == 0)
        {
            Debug.Log("Not Ammounition");
            return;
        }
        Weapon.Shoot();
        
        HUDManager.instance.UpdateArmmount();
    }
}
