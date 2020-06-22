using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public sealed class Ball : MonoBehaviour {

    [SerializeField] private Rigidbody2D rb;
    private float ballVelocity = 20f;
    private void Start() 
    {
        rb.AddForce(WeaponManager.instance.lookArm.right * ballVelocity, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        { 
            Destroy(this.gameObject);
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.LoseLife(WeaponManager.instance.Weapon.damage);
        }
        else if (collision.gameObject.tag == "Limit")
            Destroy(this.gameObject);
    }
}
