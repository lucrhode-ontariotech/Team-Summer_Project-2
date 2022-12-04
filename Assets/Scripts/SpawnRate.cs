using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRate : MonoBehaviour
{
    ObstacleSpawner spawner;
    ObstacleVariables variables;

    int currentNum;
    int lastNum;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<ObstacleSpawner>();
        variables = GetComponent<ObstacleVariables>();

        spawner.maxObstacles = 5;
        currentNum = variables.numObstaclesDestroyed;
        lastNum = currentNum;
    }

    // Update is called once per frame
    void Update()
    {
        currentNum = variables.numObstaclesDestroyed;
        
        if (currentNum > lastNum)
        {
            if (variables.numObstaclesDestroyed % 5 == 0)
            {
                spawner.maxObstacles += 2;
            }
        }

        lastNum = currentNum;
    }
}
