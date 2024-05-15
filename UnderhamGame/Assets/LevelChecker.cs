using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChecker : MonoBehaviour
{
    public int levelRequired;
    public Material green;
    public Material red;
    //public Material mat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (XPManager.CheckLevel(levelRequired)) gameObject.GetComponent<Renderer>().material = green;
        else gameObject.GetComponent<Renderer>().material = red;
    }
}
