using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecEventM1 : MonoBehaviour
{
    public GameObject[] activateEnemy;
    int enemydeath = 0;
    bool allEnemiesDeath = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < activateEnemy.Length; i++)
        {

            if (activateEnemy[i] == null)
            {
                enemydeath++;
            }
            else 
            {
                enemydeath = 0;
            }
        }

        if (enemydeath >= activateEnemy.Length && allEnemiesDeath == false)
        {
            allEnemiesDeath = true;
            DialogueHandler.StartDialogue(gameObject);
            
        }

    }
}
