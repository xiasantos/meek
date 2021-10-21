using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatGrass : MonoBehaviour
{
    public Animator sheepAnimator;
    public PlayerMovement playerMovement;
    public GameObject grass;

    private static readonly int Eating = Animator.StringToHash("Eating");


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grass"))
        {
            StartCoroutine(Eat());
            Destroy(collision.gameObject);
        }
    }

    IEnumerator Eat()
    {
        sheepAnimator.SetBool(Eating, true);
        playerMovement.moving = false;

        yield return new WaitForSeconds(2);

        playerMovement.moving = true;
        sheepAnimator.SetBool(Eating, false);
    }
    //IEnumerator Destroy()
    //{ }
}