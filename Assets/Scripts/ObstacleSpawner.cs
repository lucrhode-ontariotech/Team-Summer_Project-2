using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    GameObject obstacleObj;
    Camera cam;

    public int numOfObstacles = 0;
    public int maxObstacles = 10;

    void Start()
    {
        obstacleObj = GameObject.Find("Obstacle_Template");
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        if (numOfObstacles< maxObstacles)
        {
            spawnObject();
            numOfObstacles ++;
        }
    }

    void spawnObject()
    {
        // Generate a random point on the screen for an obstacle to fly towards
        Vector3 randomScreenPoint = new Vector3(Random.value, Random.value, 0f);

        // Convert Viewport units to World units
        Vector3 randomWorldPoint = cam.ViewportToWorldPoint(randomScreenPoint);

        float diceRollX = Random.value;
        float diceRollY = Random.value;
        float randX = 0;
        float randY = 0;

        // Randomly decide if the X value of spawn coordinates should be positive or negative
        // Must be outside of screen area
        if (diceRollX < 0.5f)
        {
            randX = Random.Range(-0.2f, 0);
        }
        else
        {
            randX = Random.Range(1, 1.2f);
        }

        // Randomly decide if the Y value of spawn coordinates should be positive or negative
        // Must be outside of screen area
        if (diceRollY < 0.5f)
        {
            randY = Random.Range(-0.2f, 0);
        }
        else
        {
            randY = Random.Range(1, 1.2f);
        }

        // Set a vector position based on randomly selected value (in Viewport units)
        Vector3 screenSpawnPoint = new Vector3(randX, randY, 0f);

        // Convert to World units
        Vector3 worldSpawnPoint = cam.ViewportToWorldPoint(screenSpawnPoint);

        // Set a Quaternion rotation to face the object in the direction of the screen point
        Quaternion cloneRotation = Quaternion.LookRotation(randomWorldPoint, Vector3.forward);

        // Create a new Obstacle_Template clone object
        // With the given spawn point
        // And rotation facing towards the screen space
        GameObject clone;
        clone = Instantiate(obstacleObj, worldSpawnPoint, cloneRotation);

        // Access ObstacleBehavior script attached to the new clone object
        // Set startMovement flag to TRUE - triggers object to move
        clone.GetComponent<ObstacleBehavior>().startMovement = true;
    }
}
