using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    PlayerVariables variables;

    // Start is called before the first frame update
    void Start()
    {
        variables = GetComponent<PlayerVariables>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((variables.immune) && (variables.immuneCount < 1))
        {
            variables.immune = false;
        }
    }
}
