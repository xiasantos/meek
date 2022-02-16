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
    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;

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
     //   if mov x gt 0
       //     lookingx = move x

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(movement.x, movement.y).normalized;

        if ((movement.x == 0 && movement.y == 0) && moveDirection.x !=0 ||moveDirection.y != 0)
        {
            lastMoveDirection = moveDirection;
        }

        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("LastHorizontal", lastMoveDirection.x);
        animator.SetFloat("LastVertical", lastMoveDirection.y);
    }

    private void FixedUpdate()
    {
        if (IsEating)
        {
            return;
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }


    private void OnSheepEating(bool eating) {
        IsEating = eating;
    }
}
