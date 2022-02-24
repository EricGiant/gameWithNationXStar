using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitBullet : MonoBehaviour
{
    public Transform goTo;
    public float moveSpeed;
    public unitAI_V2 AI;
    public float damage;

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, goTo.position, moveSpeed);
        if(transform.position == goTo.position)
        {
            if(AI.name == "soldier" || AI.name == "humvee" || AI.name == "helicopter")
            {
                if(goTo.name == "soldier" || goTo.name == "rocketeer")
                {
                    damage *= 1.5f;
                }
                else
                {
                    damage *= 0.5f;
                }
            }
            else
            {
                if(goTo.name == "soldier" || goTo.name == "rocketeer")
                {
                    damage *= 0.5f;
                }
                else
                {
                    damage *= 1.5f;
                }
            }
            Debug.Log(AI.name + " dealt " + damage);
            goTo.GetComponent<objectStats>().health -= damage;
            Destroy(gameObject);
        }
    }
}
