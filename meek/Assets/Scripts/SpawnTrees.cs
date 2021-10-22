using System.Collections.Generic;
using UnityEngine;

public class SpawnTrees : MonoBehaviour
{
    public List <GameObject> trees;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    public int treesAmount = 15;

    void Start()
    {
        for (int i = 0; i < treesAmount; i++)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        GameObject target = trees[Random.Range(0, trees.Count)];
        Instantiate(target, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

    }

    }