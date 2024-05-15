using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime 
{
    public static bool isPaused = false;
    public static float deltaTime { get { return isPaused ? 0 : Time.deltaTime; } }

    // Update is called once per frame
 
}
