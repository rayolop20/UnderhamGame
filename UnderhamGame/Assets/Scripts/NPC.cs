using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            NPCConversation component = gameObject.GetComponent<NPCConversation>();

            if (component != null)
            {
                DialogueHandler.StartDialogue(component.gameObject);
            }
        }
    }
}
