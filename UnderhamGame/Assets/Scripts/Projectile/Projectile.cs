using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileLifeTime = 2.5f;
    private float currentTimer = 0.0f;
    public int pID;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTimer += Time.deltaTime;
        if (currentTimer > projectileLifeTime)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            collision.gameObject.GetComponent<Player_Movment>().hp -= 5;
            Destroy(gameObject);
        }
    }
}
