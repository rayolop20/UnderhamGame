using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyShooter : MonoBehaviour
{
    // Start is called before the first frame update
    private Player_Movment player;
    public GameObject projectile;
    bool atack = true;
    public float atackSpeed;
    float atackSpeedReset;
    public float damage = 10f;
    public float hp;
    EnemyLogic enemyLogic;
    void Start()
    {
        player = GameObject.Find("Player").gameObject.GetComponent<Player_Movment>();
        enemyLogic = gameObject.GetComponent<EnemyLogic>();
        atackSpeedReset = atackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameTime.isPaused) return;
        if (enemyLogic.active == true) {
            if (atack == true)
            {
                CreateProjectile();
                atack = false;
            }
            else
            {
                if (atackSpeed >= 0)
                {
                    atackSpeed -= Time.deltaTime;
                }
                else
                {
                    atack = true;
                    atackSpeed = atackSpeedReset;
                }
       
       
            }
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }



    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnCollisionStay(Collision collision)
    {

    }

    private void OnCollisionExit(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerAttack" )
        {
            
            Destroy(other.gameObject);
            if (enemyLogic.active == true)
            {
                hp -= 10;
            }
       
        }
    }

    void CreateProjectile() {
         float projectileSpeed = 10f;
         Vector3 shootDirection = (player.transform.position - transform.position).normalized;
        GameObject shoot = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        shoot.GetComponent<Rigidbody>().velocity = new Vector3(shootDirection.x, shootDirection.y, shootDirection.z) * projectileSpeed;
    }

}
