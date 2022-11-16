using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    GameObject projectileObject;

    void Start()
    {
        projectileObject = GameObject.Find("Projectile_Template");
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            // Find player objects current position
            Vector3 playerPosition = this.transform.position;
            GameObject clone;

            // Create a new copy of the Projectile_Template object
            clone = Instantiate(projectileObject, this.transform.position, this.transform.rotation);

            // Access ProjectileBehavior script attached to the new clone object
            // Set startMovement flag to TRUE - triggers object to move
            ProjectileBehavior cloneScript = clone.GetComponent<ProjectileBehavior>();
            cloneScript.startMovement = true;
        }
    }
}
