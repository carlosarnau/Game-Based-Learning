using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleTextWithKey : MonoBehaviour
{
    public TextMeshProUGUI textToToggle; // Reference to the TextMeshPro text
    public KeyCode toggleKey = KeyCode.F; // Key to toggle the text

    private void Start()
    {
        // Ensure the TextMeshProUGUI component is assigned
        if (textToToggle == null)
        {
            Debug.LogError("TextMeshProUGUI component not assigned!");
        }
    }

    private void Update()
    {
        // Check if the specified key is pressed
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleText();
        }
    }

    private void ToggleText()
    {
        if (textToToggle != null)
        {
            textToToggle.enabled = !textToToggle.enabled; // Toggle the visibility
        }
    }
}