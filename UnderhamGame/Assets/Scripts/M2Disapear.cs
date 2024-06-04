using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2Disapear : MonoBehaviour
{


    public GameObject gameObject;
    // Start is called before the first frame update

    public ConversationManager conversationManager;

    bool dialogueEnd = false;
    private void OnEnable()
    {
   
        ConversationManager.OnConversationEnded += PEDROPPPPPEPERO;
    }
    private void OnDisable()
    {
      
        ConversationManager.OnConversationEnded -= PEDROPPPPPEPERO;
    }

    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueEnd == true)
        {
            gameObject.SetActive(false);
        }
    }



    void PEDROPPPPPEPERO() {
        dialogueEnd = true;
    }
}
