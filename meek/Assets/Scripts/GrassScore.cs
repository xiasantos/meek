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

    public Animator camAnimator;

    private void FixedUpdate()
    {
        grassCounterTXT.text = $"{eatGrass.grassEaten}/{spawnGrass.grassAmount}";

        if (eatGrass.grassEaten >= spawnGrass.grassAmount)
        {
            endPanel.SetActive(true);
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        camAnimator.SetTrigger("End");
        yield return new WaitForSeconds(4);
        Application.LoadLevel(Application.loadedLevel);
    }

}
