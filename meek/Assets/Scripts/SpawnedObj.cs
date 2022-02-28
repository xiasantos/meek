using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObj : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grass") || collision.gameObject.CompareTag("Tree"))
        {
            transform.position = transform.position + new Vector3(2, 2,0);
            Debug.Log("Touching");
        }
    }
}