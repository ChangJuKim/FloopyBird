using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidBody;
    [SerializeField] private LogicScript logic;
    private bool birdIsAlive = true;
    private bool classicFlight = true;
    private float flapStrength, gravityStrength;
    private float deadZoneTop = 21;
    private float deadZoneBottom = -13;

    // Start is called before the first frame update
    void Start()
    {
        getFromConstants();

        myRigidBody.gravityScale = gravityStrength;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        classicFlight = !bool.Parse(PlayerPrefs.GetString(Constants.FREE_FLIGHT_KEY));
    }

    // Update is called once per frame
    void Update()
    {
        if (checkOutOfBounds()) {
            endGame();
        }
        if (birdIsAlive)
        {
            birdMove();
        }
    }

    public bool isAlive()
    {
        return birdIsAlive;
    }

    private void getFromConstants()
    {
        if (classicFlight)
        {
            flapStrength = Constants.CLASSIC_FLAP_STRENGTH;
            gravityStrength = Constants.CLASSIC_GRAVITY;
        }
    }

    private void birdMove()
    {
        if (classicFlight) {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                myRigidBody.velocity = Vector2.up * flapStrength;
            }
        } 

        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                myRigidBody.velocity = Vector2.up * 1;
            } 
            
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                myRigidBody.velocity = Vector2.down * 1;
            } 
            
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                myRigidBody.velocity = Vector2.left * 1;
            } 
            
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                myRigidBody.velocity = Vector2.right * 1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        endGame();
    }

    private bool checkOutOfBounds()
    {
        return transform.position.y > deadZoneTop || transform.position.y < deadZoneBottom;

    }

    private void endGame()
    {
        logic.GameOver();
        birdIsAlive = false;
    }
}
