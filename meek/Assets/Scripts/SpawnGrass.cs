using UnityEngine;

public class SpawnGrass : MonoBehaviour
{
    public GameObject grass;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    public int grassAmount = 50;

    void Start()
    {
        for (int i = 0; i < grassAmount; i++)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Instantiate(grass, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

    }
}
