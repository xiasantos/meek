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
        DOTween.Init(autoKillMode, useSafeMode, logBehaviour);

    }
}
