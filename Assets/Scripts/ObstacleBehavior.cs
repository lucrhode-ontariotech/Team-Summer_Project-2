using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public bool startMovement = false;
    bool enteredScreen = false;
    float timeAlive = 0f;

    Camera cam;
    ObstacleSpawner spawnerScript;

    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        spawnerScript = GameObject.Find("Obstacle_Spawner").GetComponent<ObstacleSpawner>();
    }

    void Update()
    {
        if (startMovement)
        {
            timeAlive += Time.deltaTime;

            // Starts object movement
            this.transform.Translate(Vector2.up * Random.Range(2, 10) * Time.deltaTime);

            // Find current object position to screen space coordinates
            Vector3 objPosition = cam.WorldToViewportPoint(this.transform.position);

            // Check if object has entered the screen
            if ((objPosition.x < 1 && objPosition.x > 0) && (objPosition.y < 1 && objPosition.y > 0))
            {
                enteredScreen= true;
            }

            if (enteredScreen)
            {
                // Deletes an object if it crosses outside of camera bounds without being hit
                if (objPosition.x < 0 || objPosition.x > 1)
                {
                    DestroyObject();
                }
                else if (objPosition.y < 0 || objPosition.y > 1)
                {
                    DestroyObject();
                }
            }

            if(!enteredScreen && timeAlive > 1f)
            {
                DestroyObject();
            }
        }
    }

    void DestroyObject()
    {
        spawnerScript.numOfObstacles -= 1;
        Destroy(gameObject);
    }
}
