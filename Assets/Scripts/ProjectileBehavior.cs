using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public bool startMovement = false;
    Camera cam;

    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        if (startMovement)
        {
            // Starts object movement
            this.transform.Translate(Vector2.up * 12.0f * Time.deltaTime);

            // Find current object position to screen space coordinates
            Vector3 projectilePosition = cam.WorldToViewportPoint(this.transform.position);

            {
                // Deletes an object if it crosses outside of camera bounds
                if (projectilePosition.x < 0 || projectilePosition.x > 1)
                {
                    Destroy(gameObject);
                }
                else if (projectilePosition.y < 0 || projectilePosition.y > 1)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
