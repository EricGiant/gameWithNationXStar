using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitAI_V2 : MonoBehaviour
{
    public Transform goTo;
    public float moveSpeed, fireRate, damage, detectionRange, shootRange;
    public bool canShoot;
    public GameObject bullet;


    void Start()
    {
        transform.GetChild(0).GetComponent<CircleCollider2D>().radius = shootRange;
        transform.GetChild(1).GetComponent<CircleCollider2D>().radius = detectionRange;
        if(tag == "enemy")
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
    void FixedUpdate()
    {
        //if the object it was going to is destroyed it will return null
        //when this happens check for a new thing to find which will be a turret
        if(goTo == null)
        {
            canShoot = false;
            findTarget();
            return;
        }
        Vector3 dir = transform.position - goTo.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.position = Vector2.MoveTowards(transform.position, goTo.position, moveSpeed);
    }

    void findTarget()
    {
        Transform[] turrets;
        //look for turret first then for townhall if there are no turrets found
        if(tag == "player")
        {
            turrets = GameObject.Find("enemyTurrets").GetComponentsInChildren<Transform>();
        }
        else
        {
            turrets = GameObject.Find("playerTurrets").GetComponentsInChildren<Transform>();
        }
        //this will return 1 extra aka the parent so always do +1 when doing things
        //do try catch
        //if it catches it means all turrets are destroyed
        try
        {
            goTo = turrets[1];
            return;
        }
        catch
        {
            Debug.Log("No turrets \n go to townhall");
        }
        if(tag == "player")
        {
            goTo = GameObject.Find("enemyBuildings").transform.GetChild(0);
        }
        else
        {
            goTo = GameObject.Find("playerBuildings").transform.GetChild(0);
        }
    }

    public IEnumerator shooting()
    {
        while(canShoot)
        {
            yield return new WaitForSeconds(fireRate);
            unitBullet unitBullet = Instantiate(bullet, transform).GetComponent<unitBullet>();
            unitBullet.goTo = goTo;
            unitBullet.AI = GetComponent<unitAI_V2>();
            unitBullet.damage = damage;
        }
    }
}
