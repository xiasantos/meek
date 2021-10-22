using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrassScore : MonoBehaviour
{
    public EatGrass eatGrass;
    public SpawnGrass spawnGrass;
    public GameObject endPanel;
    public TextMeshProUGUI grassCounterTXT;

    private void FixedUpdate()
    {
        grassCounterTXT.text = $"{eatGrass.grassEaten}/{spawnGrass.grassAmount}";

        if (eatGrass.grassEaten >= spawnGrass.grassAmount)
        {
            endPanel.SetActive(true);
        }
    }

}
