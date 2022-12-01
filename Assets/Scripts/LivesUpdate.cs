using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUpdate : MonoBehaviour
{
    PlayerVariables player;
    TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerVariables>();
        tmp = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int playerLives = player.playerCurrentHP;
        tmp.text = "Player Lives: " + playerLives.ToString();
    }
}
