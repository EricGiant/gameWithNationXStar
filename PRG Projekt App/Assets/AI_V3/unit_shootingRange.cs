using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit_shootingRange : MonoBehaviour
{
    public unit_AI AI;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject == AI.goTo.gameObject)
        {
            AI.moveSpeed = 0;
            AI.startShooting();
        }
    }

}
