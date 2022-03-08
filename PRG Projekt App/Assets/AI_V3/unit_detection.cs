using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit_detection : MonoBehaviour
{
    public unit_AI AI;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(AI.goTo.tag == "turret")
        {
            if(AI.tag == "player")
            {
                if(col.tag == "enemy")
                {
                    AI.goTo = col.transform;
                }
            }
            else
            {
                if(col.tag == "player")
                {
                    AI.goTo = col.transform;
                }
            }
        }
    }
}
