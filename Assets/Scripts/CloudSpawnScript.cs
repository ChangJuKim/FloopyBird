using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloudSpawnScript : MonoBehaviour
{

    private int startingClouds = 3;

    public float spawnRate = 5;
    public GameObject cloud;
    private float timer = 0;
    private float heightOffset = 13;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));

        for (int i = 0; i < startingClouds; i++)
        {
            Vector3 position = new Vector3(Random.Range(-20, 20), getCloudY(), transform.position.z);
            Instantiate(cloud, position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnRate)
        {
            timer = 0;
            spawnCloud();
        }
    }

    private void spawnCloud()
    {
        Vector3 position = new Vector3(transform.position.x, getCloudY(), transform.position.z);
        Instantiate(cloud, position, transform.rotation);
    }

    private float getCloudY()
    {
        return Random.Range(transform.position.y - heightOffset, transform.position.y + heightOffset);
    }
}
