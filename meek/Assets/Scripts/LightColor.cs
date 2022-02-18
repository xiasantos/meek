using System.Collections;
using UnityEngine;

public class LightColor : MonoBehaviour
{
    private Coroutine cycling = null;
    private int i = 0;
    private int j = 1;

    public Light sunLight;
    public Color[] dayCycles;
    public int[] cycleDuration;
    public float duration;

    private void Start()
    {
        sunLight = GetComponent<Light>();
    }

    private void FixedUpdate()
    {
        if (cycling == null)
        {
            cycling = StartCoroutine(
                NextLightCycle(
                    sunLight, dayCycles[i], dayCycles[j], duration
                )
            );
        }
    }


    private IEnumerator NextLightCycle(Light targetLight, Color from, Color to, float duration)
    {
        var timer = 0f;

        while (timer <= duration)
        {
            timer += Time.deltaTime;
            targetLight.color = Color.Lerp(from, to, timer / duration);

            yield return null;
        }

        targetLight.color = to;

        yield return new WaitForSeconds(cycleDuration[i]);

        i = (i + 1) % dayCycles.Length;
        j = (j + 1) % dayCycles.Length;
        cycling = null;
    }
}
