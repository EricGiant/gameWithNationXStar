using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setFPS : MonoBehaviour
{
    void Start()
    {
        //otherwise the game runs at 5 fps for some reason
        //even when no code is ran or if all code is ran at once
        Application.targetFrameRate = 60;   
    }
}
