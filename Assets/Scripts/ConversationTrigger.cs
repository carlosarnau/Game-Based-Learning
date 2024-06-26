using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationTrigger : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;

    void Update()
    {
        // Check if the "F" key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Start the conversation
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }
}
