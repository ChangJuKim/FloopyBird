using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    [SerializeField] private LogicScript logic;
    private int BIRD_LAYER = 3;
    private bool gavePoint = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        gavePoint = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gavePoint && collision.gameObject.layer == BIRD_LAYER)
        {
            gavePoint = true;
            logic.AddScore(1);
        }
    }
}
