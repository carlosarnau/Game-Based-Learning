using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterAnim : MonoBehaviour
{
    string phrase = "...";
    public TextMeshProUGUI text;
    public float delay = 0.5f;
    private string staticText = "Under development";
    private Coroutine typingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        text.text = staticText; // Initialize with static text
        StartTyping();
    }

    void OnEnable()
    {
        StartTyping();
    }

    void OnDisable()
    {
        StopTyping();
    }

    void StartTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(Timer());
    }

    void StopTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
    }

    IEnumerator Timer()
    {
        while (true)
        {
            for (int i = 0; i <= phrase.Length; i++)
            {
                text.text = staticText + phrase.Substring(0, i);
                yield return new WaitForSeconds(delay);
            }
        }
    }
}