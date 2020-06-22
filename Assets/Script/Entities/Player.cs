using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private int maxLife;
    [SerializeField] private int life;
    [SerializeField] private float velocity;
    [SerializeField] private float forceJump;

    private PhysicsController physics;
    private WeaponManager weapon;

    public static Player instance;
    public int MaxLife { get { return maxLife;} }
    public int CurrentLife { get; private set; }
    public int Gold { get; set; }

    private void Awake()
    {
        instance = this;
        physics = GetComponent<PhysicsController>();
        weapon = GetComponent<WeaponManager>();       
    }

    void Start () 
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"));
	}
	
	void Update () 
    {      
        physics.Move(Input.GetAxisRaw("Horizontal") * velocity);
        physics.Jump(Input.GetKeyDown(KeyCode.Space), forceJump);
        weapon.Shoot();
    }

    public void LoseLife(int damage)
    {
        CurrentLife = maxLife - damage;
        HUDManager.instance.UpdateLife(CurrentLife);
        if(CurrentLife <= 20)
            HUDManager.instance.playerImgLife.color = Color.red;
        if (CurrentLife <= 0)
            this.gameObject.SetActive(false);
          else
            maxLife = CurrentLife;
    }

    public int GoldMount(int gold) 
    {
        Gold += gold;
        HUDManager.instance.UpdateGold(Gold);
        return Gold;          
    }
}
