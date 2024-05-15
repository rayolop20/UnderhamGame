using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour 
{ 
    public ConversationManager conversationManager;

    private void OnEnable()
    {
        ConversationManager.OnConversationStarted += HandleConversationStart_C4P;
        ConversationManager.OnConversationEnded += HandleConversationEnd_C4P;
    }
    private void OnDisable()
    {
        ConversationManager.OnConversationStarted -= HandleConversationStart_C4P;
        ConversationManager.OnConversationEnded -= HandleConversationEnd_C4P;
    }

    public static void StartDialogue(GameObject npcConversation, Rigidbody player)
    {
        NPCConversation conversation = npcConversation.GetComponent<NPCConversation>();

        ConversationManager _conversationManager = FindObjectOfType<ConversationManager>();

        _conversationManager.StartConversation(conversation);

        player.velocity = Vector3.zero;
    }

    void HandleConversationStart_C4P() { 
        GameTime.isPaused = true;
    } 
    
    void HandleConversationEnd_C4P() {
        GameTime.isPaused = false;
        // conversationManager.SetState(ConversationManager.eState.Off);
        conversationManager.TurnOffUI();
    } 
}
