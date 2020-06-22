using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public Transform lookArm;
    public Weapon Weapon;
    [SerializeField] private int currentAmmountion;
  
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
        HUDManager.instance.UpdateArmmount();       
    }

    public void Shoot()
    { 
        if (currentAmmountion == 0)
        {
            Debug.Log("Not Ammounition");
            Debug.Log("Press R to reload");
            Reload();
            return;
        }
        Weapon.Shoot();
        
        HUDManager.instance.UpdateArmmount();
    }
    public int Reload() 
    {
        if (Input.GetKey(KeyCode.R))
            currentAmmountion = AmmounitionMax;
        if (currentAmmountion == AmmounitionMax)
            AmmounitionMax = 0;
        return 0;             
    }
}
