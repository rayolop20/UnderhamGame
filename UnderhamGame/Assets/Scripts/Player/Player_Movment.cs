using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Movment : MonoBehaviour
{
    public float rotationSpeed;
    public float movementSpeed;

    public float jumpForce;

    public float jumpDistcance;
    public LayerMask Ground;
    public float hp;

    public GameObject orientation;
    public Rigidbody rb;

    [HideInInspector]public bool isJumping = false;
    public bool isRunning = false;
    public float timer = 0.0f;

    public enum MovingState
    {
        idle,run,back,attack,shoot
    }
    public MovingState mState = MovingState.idle;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (GameTime.isPaused)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        if (Input.GetKey(KeyCode.A) && mState != MovingState.attack && mState != MovingState.shoot)
        {
            gameObject.transform.Rotate(Vector3.up, -GameTime.deltaTime * rotationSpeed);
        }

        if (Input.GetKey(KeyCode.D) && mState != MovingState.attack && mState != MovingState.shoot)
        {
            gameObject.transform.Rotate(Vector3.up, GameTime.deltaTime * rotationSpeed);
        }

        if (Input.GetKey(KeyCode.W) && mState != MovingState.attack && mState != MovingState.shoot)
        {
            rb.AddForce(gameObject.transform.forward.normalized * movementSpeed * GameTime.deltaTime, ForceMode.VelocityChange);
        }

        if (mState != MovingState.attack && mState != MovingState.shoot)
        {
            if (rb.velocity.normalized.z != 0) mState = MovingState.run;
            else mState = MovingState.idle;
        }
        

        if (Input.GetKey(KeyCode.S) && mState != MovingState.attack && mState != MovingState.shoot)
        {
            mState = MovingState.back;
            rb.AddForce(gameObject.transform.forward.normalized * -movementSpeed / 3 * GameTime.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(gameObject.transform.position, Vector3.down, jumpDistcance, Ground) == true && mState != MovingState.attack && mState != MovingState.shoot)
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (mState == MovingState.attack)
        {
            timer += GameTime.deltaTime;
            if(timer > 1.0f)
            {
                mState = MovingState.idle;
                timer = 0.0f;
            }
        
        }
        if (mState == MovingState.shoot)
        {
            timer += GameTime.deltaTime;
            if(timer > 0.6f)
            {
                mState = MovingState.idle;
                timer = 0.0f;
            }
        
        }

        SpeedCap();
    }

    void SpeedCap()
    {
        Vector3 flatvel = rb.velocity;

        if (flatvel.magnitude > movementSpeed * 1.5f)
        {
            Vector3 limitedVel = flatvel.normalized * movementSpeed * 1.5f;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = false;
        }
    }

}
