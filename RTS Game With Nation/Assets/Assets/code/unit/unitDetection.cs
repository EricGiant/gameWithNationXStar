using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitDetection : MonoBehaviour
{
    unitAI_V2 AI;
    void Start()
    {
        AI = GetComponentInParent<unitAI_V2>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (!(AI.goTo.gameObject.tag == "turret" || AI.goTo.tag == "townhall")){
            return;
        }
        if(!(col.gameObject == AI.goTo.gameObject))
        {
            if(col.tag == AI.tag || col.tag == "Untagged" || col.tag == "turret" || col.tag == "townhall")
            {
                return;
            }
            AI.goTo = col.transform;
        }
    }
}
