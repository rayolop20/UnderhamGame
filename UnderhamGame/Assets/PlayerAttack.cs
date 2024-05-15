using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public Player_Movment pMov;
    public GameObject attack;
    public GameObject playerProjectile;
    public Transform attackSource;

    public float attackTimer = 0.0f;
    public float attackCooldown = 3.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Mouse0) && attackTimer >= attackCooldown)
        {
            pMov.mState = Player_Movment.MovingState.attack;
            attackTimer = 0.0f;
            GameObject mele = Instantiate(attack, attackSource.position, Quaternion.identity);
            mele.GetComponent<DieByTime>().dieTime = 0.25f;
        }
        if(Input.GetKeyDown(KeyCode.Mouse1) && attackTimer >= attackCooldown)
        {
            pMov.mState = Player_Movment.MovingState.shoot;
            attackTimer = 0.0f;
            GameObject projectile = Instantiate(playerProjectile, attackSource.position, Quaternion.identity);
            projectile.GetComponent<DieByTime>().dieTime = 5.25f;
            projectile.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward.normalized * 10.0f, ForceMode.Impulse);
        }

    }
}
