using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class XPManager : MonoBehaviour
{

    public static float experience = 0.0f;
    public string level = "Soldier";
    public static float[] levelExperience = {0,15,30};
    public TextMeshProUGUI ui;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(experience > 15.0f)
        {
            level = "Captain";
        }
        else
        {
            level = "Soldier";
        }

        ui.text = "Rango: " + level + " XP: " + experience.ToString();

        if (Input.GetKeyDown(KeyCode.Space)) experience += 5;
    }

    public static void AddExperience(float xp)
    {
        experience += xp;
    }

    public static bool CheckLevel(int requiredLvl)
    {
        if (levelExperience[requiredLvl] < experience) return true;
        else return false;
    }

}
