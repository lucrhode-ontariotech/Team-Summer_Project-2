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
    ObstacleVariables variableScript;
    PlayerVariables playerVariables;
    GameObject healthItem;
    GameObject safeItem;

    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        spawnerScript = GameObject.Find("Obstacle_Spawner").GetComponent<ObstacleSpawner>();
        variableScript = GameObject.Find("Obstacle_Spawner").GetComponent<ObstacleVariables>();
        playerVariables = GameObject.FindWithTag("Player").GetComponent<PlayerVariables>();
        healthItem = GameObject.Find("Health_Item");
        safeItem = GameObject.Find("Safe_Item");
    }

    void Update()
    {
        Movement();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for collision with objects
        // Seperate actions for "Player" and "Projectile" type objects

        if (collision.gameObject.tag == "Player")
        {
            PlayerCollision(collision);
        }
        else if (collision.gameObject.tag == "Projectile")
        {
            ProjectileCollision(collision);
        }
    }

    void DestroyObject()
    {
        // Destroy current instance of object
        // Update the current number of active spawned objects

        spawnerScript.numOfObstacles -= 1;
        Destroy(gameObject);
    }

    void ProjectileCollision(Collision2D collisionObject)
    {
        // On collision with projectile object:
        // - Destroy current instance of object
        // - Destroy the colliding object
        // - Update number of objects destroyed by player

        DestroyObject();
        Destroy(collisionObject.gameObject);
        variableScript.numObstaclesDestroyed += 1;
        if ((variableScript.numObstaclesDestroyed % 2 == 0) && (playerVariables.playerCurrentHP < playerVariables.playerMaxHP))
        {
            if (rollDice(6))
            {
                Instantiate(healthItem, this.transform.position, this.transform.rotation);
            }
            else if (rollDice(9) && !playerVariables.immune)
            {
                Instantiate(safeItem, this.transform.position, this.transform.rotation);
            }
        }
    }

    void PlayerCollision(Collision2D collisionObject)
    {
        // On collision wih player object:
        // - Destroy current instance of object
        // - Add -1 to player HP (remove 1 life)

        DestroyObject();
        if (playerVariables.immune)
        {
            playerVariables.immuneCount -= 1;
        }
        else
        {
            playerVariables.playerCurrentHP -= 1;
        }
    }

    void Movement()
    {
        if (startMovement)
        {
            timeAlive += Time.deltaTime;

            // Starts object movement
            this.transform.Translate(Vector2.up * Random.Range(1, 8) * Time.deltaTime);

            // Find current object position to screen space coordinates
            Vector3 objPosition = cam.WorldToViewportPoint(this.transform.position);

            // Check if object has entered the screen
            if ((objPosition.x < 1 && objPosition.x > 0) && (objPosition.y < 1 && objPosition.y > 0))
            {
                enteredScreen = true;
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

            // Objects that don't enter the screen under the given float value are destroyed
            // Removes objects that spawn with incorrect rotation causing them to never enter the screen
            if (!enteredScreen && timeAlive > 0.75f)
            {
                DestroyObject();
            }
        }
    }

    bool rollDice(int threshold)
    {
        bool res = false;
        int number = Random.Range(0, 11);
        if (number >= threshold)
        {
            res = true;
        }
        return res;
    }
}
