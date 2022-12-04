using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class overScreen : MonoBehaviour
{
    // Triggers game-over screen if player HP falls to 0

    PlayerVariables playerScript;

    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerVariables>();
    }

    void Update()
    {
        if (playerScript.playerCurrentHP < 1)
        {
            LoadScene("game_over");
        }
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
