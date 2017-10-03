using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ball Collision");
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
