using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    PlayerVariables playerVariables;

    // Start is called before the first frame update
    void Start()
    {
        playerVariables = GameObject.FindWithTag("Player").GetComponent<PlayerVariables>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerVariables.playerCurrentHP++;
            Destroy(gameObject);
        }
    }
}
