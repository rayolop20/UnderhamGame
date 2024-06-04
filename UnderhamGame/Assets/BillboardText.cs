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
            if (player.GetComponent<Player_Movment>().isJumping)
            {
                Vector3 newPos = new Vector3(player.transform.position.x, 0, player.transform.position.z);
                transform.LookAt(newPos);
            }
            else
            {
                transform.LookAt(player.transform.position);
            }
        }
        else
        {
            transform.LookAt(Camera.main.transform);
        }
        transform.Rotate(StartRotation);
    }

}
