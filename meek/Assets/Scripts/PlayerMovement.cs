using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Rigidbody2D rb;
    public Animator animator;


    Vector2 movement;

    public bool moving = true;
    private bool facingRight = true;

    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat(Speed, movement.sqrMagnitude);

        //if (moving)
        //{
        //    moveSpeed = 2f;
        //}
        //else
        //{
        //    moveSpeed = 0f;
        //}
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (movement.x > 0 && !facingRight)
        { Flip(); }
        else if (movement.x < 0 && facingRight)
        { Flip(); }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
