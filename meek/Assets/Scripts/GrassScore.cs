using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GrassScore : MonoBehaviour
{
    public EatGrass eatGrass;
    public SpawnGrass spawnGrass;
    public GameObject endPanel;
    public TextMeshProUGUI grassCounterTXT;
    public Animator animator;

    private void FixedUpdate()
    {
        grassCounterTXT.text = $"{eatGrass.grassEaten}/{spawnGrass.grassAmount}";

        if (eatGrass.grassEaten >= spawnGrass.grassAmount)
        {
            endPanel.SetActive(true);
            grassCounterTXT.enabled = false;
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        animator.SetBool("isGameOver", true);
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
