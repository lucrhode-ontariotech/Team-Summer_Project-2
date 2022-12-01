using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerMoveSpeed = 8.0f;
    public float playerRotateSpeed = 300.0f;
    float vAxisInput;
    float hAxisInput;

    private float boostTimer;
    private bool boosting;

    Camera cam;
    Collider2D objCollider;

    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        objCollider = GetComponent<Collider2D>();

        boostTimer = 0;
        boosting = false;
    }

    void Update()
    {
        vAxisInput = Input.GetAxis("Vertical") * playerMoveSpeed;

        // Inverted horizontal (A-D) axis for rotation
        hAxisInput = -1 * (Input.GetAxis("Horizontal")) * playerRotateSpeed;

        // Move player along the "Forard-Backward" (local Y-Axis)
        this.transform.Translate(Vector2.up * vAxisInput * Time.deltaTime);

        // Find player location relative to camera
        Vector3 playerInCamPos = cam.WorldToViewportPoint(this.transform.position);

        // Find the size of the objects collision box (convert to screen space units)
        Vector3 spriteSize = cam.WorldToViewportPoint(objCollider.bounds.size);

        /* Restricts movement values to the screen space
         * (0, 0) to (1, 1)
         * Uses the collision box to calculate object height/width
         */
        playerInCamPos.x = Mathf.Clamp(playerInCamPos.x, 0 + (spriteSize.x / 17), 1 - (spriteSize.x / 17));
        playerInCamPos.y = Mathf.Clamp(playerInCamPos.y, 0 + (spriteSize.y / 10), 1 - (spriteSize.y / 10));
        this.transform.position = cam.ViewportToWorldPoint(playerInCamPos);

        // Rotate the player character along the Z-Axis
        this.transform.Rotate(Vector3.forward * hAxisInput * Time.deltaTime);


         if (boosting)
        {
        boostTimer += Time.deltaTime;
        if (boostTimer >= 5)
            {
            playerMoveSpeed = 8.0f;
            boostTimer = 0;
            boosting = false;
            }
        }
    }

     void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "SpeedBoost")
        {
            boosting = true;
            playerMoveSpeed = 12f;
            Destroy(other.gameObject);
        }
    }
   
}
