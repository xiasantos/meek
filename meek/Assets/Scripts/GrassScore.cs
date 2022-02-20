using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
        yield return new WaitForSeconds(4);
        camAnimator.Play("StartCam");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }

}
