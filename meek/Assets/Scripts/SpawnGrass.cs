using System.Collections.Generic;
using UnityEngine;

public class SpawnGrass : MonoBehaviour
{
    public GameObject grass;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timebetweenSpawn;
    private float spawnTime;

    void Update()
    {

        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timebetweenSpawn;
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Instantiate(grass, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

    }
}
