using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PosRayCollison
{
    public Vector2 down;
    public Vector2 up;
    public Vector2 left;
    public Vector2 right;
}
[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class PhysicsController : MonoBehaviour {

    new private Collider2D collider;
    private Rigidbody2D rb;

    private PosRayCollison posRay;
    private float skinWidht = 0.02f;
    private bool lookBackwards;
    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        CalculateRay();
    }

    private void CalculateRay()
    {
        //Down
        Vector2 posCurrent = collider.bounds.center;
        posCurrent.y = collider.bounds.min.y  + skinWidht;

        posRay.down = posCurrent;

        //Up
        posCurrent = collider.bounds.center;
        posCurrent.y = collider.bounds.max.y - skinWidht;
        posRay.up = posCurrent;

        //Left
        posCurrent = collider.bounds.center;
        posCurrent.x = collider.bounds.min.x + skinWidht;
        posRay.left = posCurrent;

        //Right
        posCurrent = collider.bounds.center;
        posCurrent.x = collider.bounds.max.x - skinWidht;
        posRay.right = posCurrent;

#if UNITY_EDITOR
        Debug.DrawRay(posRay.down, new Vector2(0, -0.05f), Color.blue);
        Debug.DrawRay(posRay.up, Vector2.up, Color.blue);
        Debug.DrawRay(posRay.left, Vector2.left, Color.blue);
        Debug.DrawRay(posRay.right, Vector2.right, Color.blue);
#endif
    }

    public void Move(float velocity)
    {
        rb.velocity = new Vector2(velocity, rb.velocity.y);
        if (velocity < 0 && !lookBackwards)
            Flip();
        else if (velocity > 0 && lookBackwards)
            Flip();
    }

    public void Jump(bool pressedInput, float forceJump)
    {
        int layerGround = 1 << 9;

        RaycastHit2D hit = Physics2D.Raycast(posRay.down, Vector2.down, 0.05f, layerGround);

        if (pressedInput && hit.collider != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, forceJump);
        }

        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - rb.gravityScale);
    }
    public void Flip() 
    {
        lookBackwards = !lookBackwards;
        transform.Rotate(0f, 180f, 0f);
    }
}
