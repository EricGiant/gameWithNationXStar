using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitShootingRange : MonoBehaviour
{
    unitAI_V2 AI;
    public float oldMoveSpeed;

    void Start()
    {
        AI = GetComponentInParent<unitAI_V2>();
        //save the unit move speed so it can be added back later
        oldMoveSpeed = AI.moveSpeed;
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        //if the colided gameObject is the same as the target object
        //stop moving and start shooting
        if(col.gameObject == AI.goTo.gameObject)
        {
            AI.moveSpeed = 0;
            AI.canShoot = true;
            StartCoroutine(AI.shooting());
        }
    }
}
