using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardText : MonoBehaviour
{
    public Vector3 StartRotation = Vector3.zero;
    public bool followPlayer = false;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(followPlayer)
        {
            transform.LookAt(player.transform);
        }
        else
        {
            transform.LookAt(Camera.main.transform);
        }
        transform.Rotate(StartRotation);
    }

}
