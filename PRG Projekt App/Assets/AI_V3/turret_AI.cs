using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret_AI : MonoBehaviour
{
    Transform goTo;
    public bool isPlayer;
    public GameObject bullet;
    public float damage;
    public float fireRate;
    public CircleCollider2D shootingRange;
    public bool hasMiniGun, hasCannon;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(isPlayer)
        {
            if(col.tag == "enemy" && goTo == null)
            {
                goTo = col.transform;
                StartCoroutine("shooting");
            }
        }
        else
        {
            if(col.tag == "player" && goTo == null)
            {
                goTo = col.transform;
                StartCoroutine("shooting");
            }
        }
    }

    IEnumerator shooting()
    {
        while(true)
        {
            yield return new WaitForSeconds(fireRate);
            Debug.Log("fire turret");
            if(goTo == null)
            {
                shootingRange.enabled = false;
                shootingRange.enabled = true;
                StopCoroutine("shooting");
            }
            GameObject bul = Instantiate(bullet, transform);
            bullet_turret_AI bul_AI = bul.GetComponent<bullet_turret_AI>();
            bul_AI.goTo = goTo;
            bul_AI.hasCannon = hasCannon;
            bul_AI.hasMiniGun = hasMiniGun;
            bul_AI.damage = damage;
        }
    }
}
