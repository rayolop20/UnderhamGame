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

        if (GameTime.isPaused) return;

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
            if (rb.velocity.normalized.z > 0) mState = MovingState.run;
            else mState = MovingState.idle;
        }
        

        if (Input.GetKey(KeyCode.S) && mState != MovingState.attack && mState != MovingState.shoot)
        {
            mState = MovingState.back;
            rb.AddForce(gameObject.transform.forward.normalized * -movementSpeed / 3 * GameTime.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(gameObject.transform.position, Vector3.down, jumpDistcance, Ground) == true && mState != MovingState.attack && mState != MovingState.shoot)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (mState == MovingState.attack)
        {
            timer += GameTime.deltaTime;
            if(timer > 2.5f)
            {
                mState = MovingState.idle;
                timer = 0.0f;
            }
        
        }
        if (mState == MovingState.shoot)
        {
            timer += GameTime.deltaTime;
            if(timer > 1.0f)
            {
                mState = MovingState.idle;
                timer = 0.0f;
            }
        
        }

        SpeedCap();
    }

    void SpeedCap()
    {
        Vector3 flatvel = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);

        if (flatvel.magnitude > movementSpeed * 1f)
        {
            Vector3 limitedVel = flatvel.normalized * movementSpeed * 0.2f;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

}
