using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class immunity : MonoBehaviour
{
    PlayerVariables player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerVariables>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.immune = true;
            player.immuneCount = 3;
            Destroy(gameObject);
        }
        
    }
}
