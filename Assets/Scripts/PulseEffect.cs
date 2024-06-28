using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PulseEffect : MonoBehaviour
{
    public float minScale = 0.8f; // Minimum scale factor
    public float maxScale = 1.2f; // Maximum scale factor
    public float pulseSpeed = 1.0f; // Speed of the pulsing effect

    private TextMeshProUGUI textComponent;

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        if (textComponent == null)
        {
            Debug.LogError("TextMeshProUGUI component not found!");
            return;
        }
        StartCoroutine(Pulse());
    }

    private IEnumerator Pulse()
    {
        // Initially scale to the minimum scale to avoid sudden resizing
        textComponent.transform.localScale = new Vector3(minScale, minScale, minScale);

        // Loop the pulsing effect
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