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
        if(goTo == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = transform.position - goTo.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position = Vector2.MoveTowards(transform.position, goTo.position, moveSpeed);
        //for some weird reason the z axis is 0 for the unit bullet and -5 for the goto when it's a turret
        //so it will just look for x and y
        if(transform.position.x == goTo.position.x && transform.position.y == goTo.position.y)
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
