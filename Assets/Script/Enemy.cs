using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] private int life;
    [SerializeField] private int damage;

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

    public void LoseLife(int damage)
    {
        int curLife = life - damage;

        if (curLife <= 0)
            Destroy(this.gameObject);
        else
            life = curLife;
    }
}
