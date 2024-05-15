using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class TP_ToEvent : MonoBehaviour
{
        
    public void TeleportToEvent1()
    {
        SceneManager.LoadScene("Missio_1");
    }
    
    public void TeleportToEvent2()
    {
        XPManager.experience += 15;
        SceneManager.LoadScene("SampleScene");

        
    }
    public void TeleportToEvent3()
    {
        XPManager.experience -= 15;
        SceneManager.LoadScene("SampleScene");
        
    }

}
