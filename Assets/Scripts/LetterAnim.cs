using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterAnim : MonoBehaviour
{
    string phrase = "...";
    public Text text;
    public float delay = 0.5f;  // Ajustar este valor para cambiar la velocidad de la animación
    private string baseText;    // Almacena el texto base

    // Start is called before the first frame update
    void Start()
    {
        baseText = text.text;   // Guarda el texto inicial del objeto Text
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (true)
        {
            for (int i = 0; i <= phrase.Length; i++)
            {
                text.text = baseText + phrase.Substring(0, i);
                yield return new WaitForSeconds(delay);
            }
        }
    }
}