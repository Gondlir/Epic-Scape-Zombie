using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] private Transform target;
    [SerializeField] private float velocity;

    private PhysicsController physicsController;

    private void Awake()
    {
        physicsController = GetComponent<PhysicsController>();
    }

    private void Update()
    {
        float followPos = (target.position.x > this.transform.position.x) ? velocity : -velocity;
        physicsController.Move(followPos);
    }
}
