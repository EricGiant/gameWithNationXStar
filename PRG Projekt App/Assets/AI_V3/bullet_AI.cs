using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_AI : MonoBehaviour
{
    public unit_AI AI;
    public float moveSpeed;
    public Transform goTo;
    public float damage;

    void Start()
    {
        //do try catch
        //if caught destroy bullet because it means the goTo is goon
        try
        {
            //set rotation for first frame
            Vector3 dir = transform.position - goTo.position;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            //calculate dmg
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
        }
        catch
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        //do try catch
        //if caught destroy bullet because it means the goTo is goon
        try
        {
            //rotate bullet towards target
            Vector3 dir = transform.position - goTo.position;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            //move bullet to target
            transform.position = Vector2.MoveTowards(transform.position, goTo.position, moveSpeed);
            if(transform.position == goTo.position)
            {
                goTo.GetComponent<objectStats>().health -= damage;
                Destroy(gameObject);
            }
        }
        catch
        {
            Destroy(gameObject);
        }
    }
}