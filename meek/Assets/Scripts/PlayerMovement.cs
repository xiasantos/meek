using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Rigidbody2D rb;
    public Animator animator;

    public bool IsEating { get; private set; } = false;

    private Vector2 movement;
    private bool facingRight = true;
    private static readonly int Speed = Animator.StringToHash("Speed");


    private void OnEnable()
    {
        EatGrass.SheepEating += OnSheepEating;
    }

    private void OnDisable()
    {
        EatGrass.SheepEating -= OnSheepEating;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat(Speed, movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        if (IsEating)
        {
            return;
        }

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

    private void OnSheepEating(bool eating) {
        IsEating = eating;
    }
}
