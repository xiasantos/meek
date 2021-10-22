using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class EatGrass : MonoBehaviour
{
    public Animator sheepAnimator;
    public GameObject grass;
    public float grassEaten;
    private GameObject grassCollided;
    //public TextMeshProUGUI grassScore;

    private static readonly int Eating = Animator.StringToHash("Eating");

    public static event Action<bool> SheepEating;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grass"))
        {
            SheepEating?.Invoke(true);
            grassCollided = collision.gameObject;
            StartCoroutine(Eat());
            
            //score animation!!
        }
    }

    IEnumerator Eat()
    {
        sheepAnimator.SetBool(Eating, true);
     
        yield return new WaitForSeconds(2);

        AddCount(1);
        SheepEating?.Invoke(false);
        sheepAnimator.SetBool(Eating, false);
        Destroy(grassCollided);
    }

    public void AddCount(int amount)
    {
        grassEaten += amount;
    }

}