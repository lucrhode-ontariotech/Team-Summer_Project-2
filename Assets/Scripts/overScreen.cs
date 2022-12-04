using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class overScreen : MonoBehaviour
{
    // Triggers game-over screen if player HP falls to 0

    PlayerVariables playerScript;
    GameObject musicObj;

    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerVariables>();
        musicObj = GameObject.Find("MainMusic");
    }

    void Update()
    {
        if (playerScript.playerCurrentHP < 1)
        {
            Destroy(musicObj);
            LoadScene("game_over");
        }
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
