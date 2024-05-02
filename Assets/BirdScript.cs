using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public LogicScript logic;
    private float flapStrength = 20;
    private float gravityStrength = 4.5F;
    private bool birdIsAlive = true;
    private float deadZoneTop = 21;
    private float deadZoneBottom = -13;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody.gravityScale = gravityStrength;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkOutOfBounds()) {
            endGame();
        }
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
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
        logic.gameOver();
        birdIsAlive = false;
    }
}
