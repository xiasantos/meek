using System.Collections;
using UnityEngine;
using TMPro;

public class StartGame : MonoBehaviour
{
    public TextMeshProUGUI grassCounter;
    public TextMeshProUGUI eatGrass;
    public GameObject restartButton;

    void Start()
    {
        StartCoroutine(CounterOn());
    }
    IEnumerator CounterOn()
    {
        yield return new WaitForSeconds(4);
        eatGrass.enabled = false;
        grassCounter.enabled = true;
        restartButton.SetActive(true);
    }
}
