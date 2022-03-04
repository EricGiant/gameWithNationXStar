using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class townHall : MonoBehaviour
{
    public float waitTime;
    public int amountGiven;
    currency gold;
    public bool isPlayer; //check if TW is player or enemy

    void Start()
    {
        //if it's a player it starts the code to give the player money
        if(isPlayer)
        {
            gold = GameObject.Find("goldCounter").GetComponent<currency>();
            StartCoroutine(giveGold());
        }
        //if it's enemy it stats the enemy AI code
        else
        {
            gameObject.AddComponent<enemyAI>();
        }
    }

    IEnumerator giveGold()
    {
        //give gold every set time
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            gold.gold += amountGiven;
            Debug.Log("give gold");
        }
    }
}
