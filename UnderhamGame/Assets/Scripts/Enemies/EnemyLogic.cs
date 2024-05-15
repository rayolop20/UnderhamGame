using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;


enum ENEMY_TYPE
{
    MELE,
    SHOOTER,
}

public class EnemyLogic : MonoBehaviour
{

    private NavMeshAgent enemy;
    Transform player;
    Vector3 objective;
    [HideInInspector] public bool active = false;
    public Vector3 returnPosition;
    ENEMY_TYPE typeEnemy;
    float speed;
    public float backSpeed;

    // Start is called before the first frame update


    void Start()
    {

        player = GameObject.Find("Player").GetComponent<Transform>();
        enemy = GetComponent<NavMeshAgent>();
        returnPosition = gameObject.transform.position;
        speed = enemy.speed;
        if (gameObject.tag == "EnemyMele")
        {
            typeEnemy = ENEMY_TYPE.MELE;
        }
        else if (gameObject.tag == "EnemyShooter")
        {
            typeEnemy = ENEMY_TYPE.SHOOTER;
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (GameTime.isPaused) return;
        switch (typeEnemy)
        {
            case ENEMY_TYPE.MELE:
                objective = player.transform.position;
                break;
            case ENEMY_TYPE.SHOOTER:
                float stoppingDistance = -5;
                Vector3 directionToPlayer = player.transform.position - transform.position;

                objective = player.transform.position + directionToPlayer.normalized * stoppingDistance;

                break;
            default:
                break;
        }

        if (active == true)
        {
            enemy.speed = speed;
            enemy.SetDestination(objective);
        }
        else if (active == false)
        {
            enemy.speed = backSpeed;
            enemy.transform.LookAt(player.transform.position);
            enemy.SetDestination(returnPosition);
        }


    }

    

}
