using Random = UnityEngine.Random;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

public class EatGrass : MonoBehaviour
{
    public Animator sheepAnimator;
    public GameObject grass;
    private GameObject grassCollided;
    public float grassEaten;

    public List<AudioClip> audioClips;
    public AudioClip currentClip;
    public AudioSource source;

    private static readonly int Eating = Animator.StringToHash("Eating");

    public static event Action<bool> SheepEating;


    private void Start()
    {
        source = GetComponent<AudioSource>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grass"))
        {
            SheepEating?.Invoke(true);
            grassCollided = collision.gameObject;
            currentClip = audioClips[Random.Range(0, audioClips.Count)];
            source.clip = currentClip;
            source.Play();
            StartCoroutine(Eat());

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