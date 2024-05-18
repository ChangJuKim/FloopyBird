using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidBody;
    [SerializeField] private LogicScript logic;
    private bool birdIsAlive = true;
    private bool classicFlight;
    public float flapStrength, gravityStrength;

    // Start is called before the first frame update
    void Start()
    {
        getFromConstants();

        myRigidBody.gravityScale = gravityStrength;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOutOfBounds()) {
            EndGame();
        }
        if (birdIsAlive)
        {
            BirdMove();
        }
    }

    public bool GetIsAlive()
    {
        return birdIsAlive;
    }

    private void getFromConstants()
    {
        classicFlight = !bool.Parse(PlayerPrefs.GetString(Constants.IS_FF_KEY));

        if (classicFlight)
        {
            flapStrength = Constants.CLASSIC_FLAP_STRENGTH;
            gravityStrength = Constants.CLASSIC_GRAVITY;
        }
        else
        {
            flapStrength = Constants.FF_FLAP_STRENGTH;
            gravityStrength = Constants.FF_GRAVITY;
        }
    }

    private void BirdMove()
    {
        if (classicFlight) {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                myRigidBody.velocity = Vector2.up * flapStrength * Time.deltaTime;
            }
        } 

        else
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                myRigidBody.velocity += Vector2.up * flapStrength * Time.deltaTime;
            } 
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                myRigidBody.velocity += Vector2.down * flapStrength * Time.deltaTime;
            } 
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                myRigidBody.velocity += Vector2.left * flapStrength * Time.deltaTime;
            } 
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                myRigidBody.velocity += Vector2.right * flapStrength * Time.deltaTime;
            }

            if (myRigidBody.velocity.magnitude > Constants.FF_MAX_VELOCITY)
            {
                myRigidBody.velocity = myRigidBody.velocity.normalized * Constants.FF_MAX_VELOCITY;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }

    private bool IsOutOfBounds()
    {
        return transform.position.y > Constants.DEAD_ZONE_TOP ||
            transform.position.y < Constants.DEAD_ZONE_BOT ||
            transform.position.x > Constants.DEAD_ZONE_RIGHT ||
            transform.position.x < Constants.DEAD_ZONE_LEFT;

    }

    private void EndGame()
    {
        logic.GameOver();
        birdIsAlive = false;
    }
}
