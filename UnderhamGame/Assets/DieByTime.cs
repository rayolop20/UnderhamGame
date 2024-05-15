using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieByTime : MonoBehaviour
{
    // Start is called before the first frame update

    public float dieTime = 0.0f;
    public float timer = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= dieTime) Destroy(gameObject);
    }

    

}
