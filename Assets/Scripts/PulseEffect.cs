using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PulseEffect : MonoBehaviour
{
    public float minScale = 0.8f;
    public float maxScale = 1.2f;
    public float pulseSpeed = 1.0f;

    private TextMeshProUGUI textComponent;
    private Coroutine pulseCoroutine;

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        if (textComponent == null)
        {
            Debug.LogError("TextMeshProUGUI component not found!");
            return;
        }
        StartPulse();
    }

    private void OnEnable()
    {
        StartPulse();
    }

    private void OnDisable()
    {
        StopPulse();
    }

    private void StartPulse()
    {
        if (pulseCoroutine != null)
        {
            StopCoroutine(pulseCoroutine);
        }
        pulseCoroutine = StartCoroutine(Pulse());
    }

    private void StopPulse()
    {
        if (pulseCoroutine != null)
        {
            StopCoroutine(pulseCoroutine);
            pulseCoroutine = null;
        }
    }

    private IEnumerator Pulse()
    {
        textComponent.transform.localScale = new Vector3(minScale, minScale, minScale);

        while (true)
        {
            // Scale up
            yield return StartCoroutine(ScaleText(maxScale));
            // Scale down
            yield return StartCoroutine(ScaleText(minScale));
        }
    }

    private IEnumerator ScaleText(float targetScale)
    {
        Vector3 startScale = textComponent.transform.localScale;
        Vector3 endScale = new Vector3(targetScale, targetScale, targetScale);
        float elapsedTime = 0.0f;

        while (elapsedTime < pulseSpeed)
        {
            textComponent.transform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / pulseSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        textComponent.transform.localScale = endScale;
    }
}