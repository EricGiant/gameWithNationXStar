using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBullet : MonoBehaviour
{
    public Transform goTo;
    public float moveSpeed;
    public float damage;
    public bool hasMiniGun, hasCannon;

    void FixedUpdate()
    {
        if(goTo == null)
        {
            Destroy(gameObject);
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position, goTo.position, moveSpeed);
        if(transform.position == goTo.position)
        {
            //damage calculation
            if(goTo.name == "humvee" || goTo.name == "tank" || goTo.name == "helicopter" || goTo.name == "fighterJet")
            {
                if(hasCannon)
                {
                    damage *= 1.5f;
                }
                else
                {
                    damage *= 0.5f;
                }
            }
            else if(goTo.name == "soldier" || goTo.name == "rocketeer")
            {
                if(hasMiniGun)
                {
                    damage *= 1.5f;
                }
                else
                {
                    damage *= 0.5f;
                }
            }
            goTo.GetComponent<objectStats>().health -= damage;
            Destroy(gameObject);
        }
    }
}
