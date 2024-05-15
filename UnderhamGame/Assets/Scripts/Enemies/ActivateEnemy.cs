using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivateEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyLogic[] enemy;
    [HideInInspector] public bool dialogueEnd = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            for (int i = 0; i < enemy.Length; i++) 
            {
                if (enemy[i] != null)
                {
                    NPCConversation component = enemy[i].GetComponent<NPCConversation>();

                    if (component != null && dialogueEnd == false)
                    {
                        DialogueHandler.StartDialogue(enemy[i].gameObject);
                        dialogueEnd = true;
                    }
                }


                
            }


        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && dialogueEnd == true)
        {
            foreach (var item in enemy)
            {
                item.active = EnemyPathfindTrue(true);
            }

        }

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (var item in enemy)
            {
                item.active = EnemyPathfindTrue(false);
            }
        }
    }

    bool EnemyPathfindTrue(bool hasEnter) {

        return hasEnter;
    }


}
