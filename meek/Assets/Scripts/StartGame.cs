using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class StartGame : MonoBehaviour
{
    public TextMeshProUGUI grassCounter;

    void Start()
    {
        StartCoroutine(CounterOn());
    }
    IEnumerator CounterOn()
    {
        yield return new WaitForSeconds(4);
        grassCounter.enabled = true;
    }
}
