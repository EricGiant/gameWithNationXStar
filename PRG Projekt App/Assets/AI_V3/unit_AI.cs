using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit_AI : MonoBehaviour
{
    public Transform goTo;
    float oldMoveSpeed;
    public IEnumerator shooting_IE;
    public CircleCollider2D detection, shootingRange;
    public GameObject bullet;
    public float damage;
    public float fireRate;
    public float moveSpeed;
    public float detectionRange, shootingRange_value;
    
    void Start()
    {
        oldMoveSpeed = moveSpeed;
        shooting_IE = shooting();
        detection.radius = detectionRange;
        shootingRange.radius = shootingRange_value;
        if(tag == "enemy")
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        }
    }

    void FixedUpdate()
    {
        //check if the unit has some where to go to
        //if not find a target
        if(goTo == null)
        {
            StopCoroutine("shooting");
            moveSpeed = oldMoveSpeed;
            //disable then enable detection to reset the enter
            detection.enabled = false;
            detection.enabled = true;
            shootingRange.enabled = false;
            shootingRange.enabled = true;
            findTarget();
        }
        //rotate unit towards target
        Vector3 dir = transform.position - goTo.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        //move unit to target
        transform.position = Vector2.MoveTowards(transform.position, goTo.position, moveSpeed);
    }

    public void startShooting()
    {
        StartCoroutine("shooting");
    }

    void findTarget()
    {
        SpriteRenderer[] targets;
        //first look for turrets
        //find the sprite render component to get the object
        if(tag == "player")
        {
            targets = GameObject.Find("enemyTurrets").GetComponentsInChildren<SpriteRenderer>();
        }
        else
        {
            targets = GameObject.Find("playerTurrets").GetComponentsInChildren<SpriteRenderer>();
        }
        //if this length is 0 it means there are no turrets remaining and the unit has to go the the townhall
        if(targets.Length == 0)
        {
            if(tag == "player")
            {
                goTo = GameObject.Find("enemyBuildings").transform.GetChild(0);
            }
            else
            {
                goTo = GameObject.Find("playerBuildings").transform.GetChild(0);
            }
        }
        else
        {
            goTo = targets[0].transform;
        }
    }

    public IEnumerator shooting()
    {
        while(true)
        {
            yield return new WaitForSeconds(fireRate);
            Debug.Log("fire");
            GameObject bul = Instantiate(bullet, transform);
            bullet_AI bul_AI = bul.GetComponent<bullet_AI>();
            bul_AI.AI = GetComponent<unit_AI>();
            bul_AI.goTo = goTo;
            bul_AI.damage = damage;
        }
    }
}
