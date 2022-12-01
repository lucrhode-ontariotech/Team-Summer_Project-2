using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class overScreen : MonoBehaviour
{
    PlayerVariables playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerVariables>();
    }

    // Update is called once per frame
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
