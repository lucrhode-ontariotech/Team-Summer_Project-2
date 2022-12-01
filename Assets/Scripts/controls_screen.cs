using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controls_screen : MonoBehaviour
{
    public void onButtonPress()
    {
        LoadScene("Controls_Screen");
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
