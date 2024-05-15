using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinTest : MonoBehaviour
{
    public GameObject Enemy;
    //public DialogueHandler dialogueHandler;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //DialogueHandler.StartDialogue(gameObject);
    }
}
