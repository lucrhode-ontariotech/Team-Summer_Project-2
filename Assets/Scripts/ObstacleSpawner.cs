using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    GameObject obstacleObj;
    Camera cam;

    public int numOfObstacles = 0;
    public int maxObstacles = 0;

    void Start()
    {
        obstacleObj = GameObject.Find("Obstacle_Template");
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        // Constantly checks wether the current number of active spawned objects is less than allowed maximum
        // Spawns new objects and updates the number whenever the current value falls below the maximum value
        if (numOfObstacles < maxObstacles)
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
        randomWorldPoint.z = 0f;

        float diceRollX = Random.value;
        float diceRollY = Random.value;
        float randX = 0f;
        float randY = 0f;
        float rotateAngle = 0f;

        // Randomly decide if the X value of spawn coordinates should be positive or negative
        // Must be outside of screen area
        if (diceRollX < 0.5f)
        {
            randX = Random.Range(-0.15f, 0);
        }
        else
        {
            randX = Random.Range(1, 1.15f);
        }

        // Randomly decide if the Y value of spawn coordinates should be positive or negative
        // Must be outside of screen area
        if (diceRollY < 0.5f)
        {
            randY = Random.Range(-0.15f, 0);
        }
        else
        {
            randY = Random.Range(1, 1.15f);
        }

        // Set a vector position based on randomly selected value (in Viewport units)
        Vector3 screenSpawnPoint = new Vector3(randX, randY, 0f);

        // Convert to World units
        Vector3 worldSpawnPoint = cam.ViewportToWorldPoint(screenSpawnPoint);
        worldSpawnPoint.z = 0f;

        if (randX < 0)
        {
            rotateAngle = -1 * (Vector2.Angle(worldSpawnPoint, randomWorldPoint));
        }
        else
        {
            rotateAngle = Vector2.Angle(worldSpawnPoint, randomWorldPoint);
        }

        /* At this stage objects should have a rotation facing towards the screen.
        For unknown reasons objects may not always have correct rotation */

        Quaternion angleQuat = Quaternion.Euler(0f, 0f, rotateAngle);

        // Create a new Obstacle_Template clone object
        // With the given spawn point
        // And rotation facing towards the screen space
        GameObject clone;
        clone = Instantiate(obstacleObj, worldSpawnPoint, angleQuat);

        // Access ObstacleBehavior script attached to the new clone object
        // Set startMovement flag to TRUE - triggers object to move
        clone.GetComponent<ObstacleBehavior>().startMovement = true;
    }
}
