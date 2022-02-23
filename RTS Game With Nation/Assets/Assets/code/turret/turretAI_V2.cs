using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretAI_V2 : MonoBehaviour
{
    public bool isPlayer;
    public float fireRate;
    public float damage;
    public GameObject bullet;
    public bool hasMiniGun, hasCannon;
    Transform goTo;
    bool canShoot;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(isPlayer && col.tag == "enemy")
        {
        }
        else if(!isPlayer && col.tag == "player")
        {
        }
        else
        {
            return;
        }
        goTo = col.transform;
        canShoot = true;
        StartCoroutine(shooting());
    }

    void OnTriggerExit2D(Collider2D col)
    {
        canShoot = false;
    }

    IEnumerator shooting()
    {
        while(canShoot)
        {
            yield return new WaitForSeconds(fireRate);
            turretBullet turretBullet = Instantiate(bullet, transform).GetComponent<turretBullet>();
            turretBullet.goTo = goTo;
            turretBullet.damage = damage;
            turretBullet.hasMiniGun = hasMiniGun;
            turretBullet.hasCannon = hasCannon;
        }
    }
}
