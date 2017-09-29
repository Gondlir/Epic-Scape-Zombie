using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float velocity;
    [SerializeField] private float forceJump;

    private PhysicsController physics;

    private void Awake()
    {
        physics = GetComponent<PhysicsController>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        physics.Move(Input.GetAxisRaw("Horizontal") * velocity);
        physics.Jump(Input.GetKeyDown(KeyCode.Z), forceJump);
    }
}
