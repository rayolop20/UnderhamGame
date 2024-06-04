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
    
    public void TeleportToMission2()
    {
        if (XPManager.experience >= 50)
        {
            SceneManager.LoadScene("Missio_2");
        }

    }
    
    public void TeleportToEvent2()
    {
        XPManager.experience += 15;
        GameTime.isPaused = false;
        SceneManager.LoadScene("SampleScene");

        
    }
    public void TeleportToEvent3()
    {
        XPManager.experience -= 15;
        GameTime.isPaused = false;
        SceneManager.LoadScene("SampleScene");
        
    }

}
