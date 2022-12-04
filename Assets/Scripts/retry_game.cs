using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry_game : MonoBehaviour
{
    // Loads the menu screen on button press
    // Allows players to retry after a game-over

    public void onButtonPress()
    {
        LoadScene("opening_scene");
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
