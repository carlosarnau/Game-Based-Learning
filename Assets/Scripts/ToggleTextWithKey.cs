using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleTextWithKey : MonoBehaviour
{
    public TextMeshProUGUI textToToggle;
    public KeyCode toggleKey = KeyCode.F;

    private void Start()
    {
        if (textToToggle == null)
        {
            Debug.LogError("TextMeshProUGUI component not assigned!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleText();
        }
    }

    private void ToggleText()
    {
        if (textToToggle != null)
        {
            textToToggle.enabled = !textToToggle.enabled;
        }
    }
}