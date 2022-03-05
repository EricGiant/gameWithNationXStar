using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class townHall : MonoBehaviour
{
    public float waitTime;
    public int amountGiven;
    currency gold;
    public bool isPlayer; //check if TW is player or enemy
    public int level;
    public Sprite[] textures;

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
    
    //select the right texture
    //because there are only 2 textures you have to do -1 to find the right 1
    public void selectTexture()
    {
        GetComponent<SpriteRenderer>().sprite = textures[level - 1];
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
