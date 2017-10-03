using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private int maxLife;

    [SerializeField] private float velocity;
    [SerializeField] private float forceJump;


    private PhysicsController physics;
    private WeaponManager weapon;

    public static Player instance;

    public int MaxLife { get { return maxLife;} }
    public int CurrentLife { get; set; }

    public int Gold { get; set; }

    private void Awake()
    {
        instance = this;
        physics = GetComponent<PhysicsController>();
        weapon = GetComponent<WeaponManager>();
    }

    // Use this for initialization
    void Start () {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"));
	}
	
	// Update is called once per frame
	void Update () {
        
        physics.Move(Input.GetAxisRaw("Horizontal") * velocity);
        physics.Jump(Input.GetKeyDown(KeyCode.Z), forceJump);

        weapon.Shoot();
    }
}
