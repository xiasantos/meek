using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAnimator : MonoBehaviour
{
    private static readonly int Eating = Animator.StringToHash("Eating");

    public Animator animator;

    protected Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
  
       // animator.SetFloat(Eating, )
    }
}
