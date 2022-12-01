using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    ObstacleVariables obsScript;
    TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        obsScript = GameObject.Find("Obstacle_Spawner").GetComponent<ObstacleVariables>();
        tmp = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int score = (obsScript.numObstaclesDestroyed) * 500;
        tmp.text = "SCORE: " + score.ToString();
    }
}
