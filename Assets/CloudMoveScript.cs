using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CloudMoveScript : MonoBehaviour
{
    // Speed from 1.5 to 3.5
    private float baseSpeed = 2.5F;
    private float speedOffset = 1F;
    private float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Random.Range(baseSpeed - speedOffset, baseSpeed + speedOffset);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
