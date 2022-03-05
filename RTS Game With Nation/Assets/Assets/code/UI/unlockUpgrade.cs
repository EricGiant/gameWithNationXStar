using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unlockUpgrade : MonoBehaviour
{
    public int price, healthIncrease;
    public int incomeIncrease;

    //each upgrade first checks if oyu have enough money
    //then if you do have enoug it removes the money from your bank
    //then gives you the upgrade and disables the button
    public void unlockMiniGun()
    {
        if(GameObject.Find("goldCounter").GetComponent<currency>().gold < price)
        {
            Debug.Log("cant buy minigun");
            return;
        }
        GameObject.Find("goldCounter").GetComponent<currency>().gold -= price;
        foreach(turretAI_V2 go in GameObject.Find("playerTurrets").GetComponentsInChildren<turretAI_V2>())
        {
            go.hasMiniGun = true;
        }
        GetComponent<Button>().interactable = false;
    }

    public void unlockCannon()
    {
        if(GameObject.Find("goldCounter").GetComponent<currency>().gold < price)
        {
            Debug.Log("cant buy cannon");
            return;
        }
        GameObject.Find("goldCounter").GetComponent<currency>().gold -= price;
        foreach(turretAI_V2 go in GameObject.Find("playerTurrets").GetComponentsInChildren<turretAI_V2>())
        {
            go.hasCannon = true;
        }
        GetComponent<Button>().interactable = false;
    }

    public void upgradeHealth()
    {
        if(GameObject.Find("goldCounter").GetComponent<currency>().gold < price)
        {
            Debug.Log("cant upgrade health");
            return;
        }
        GameObject.Find("goldCounter").GetComponent<currency>().gold -= price;
        GameObject playerBuildings = GameObject.Find("playerBuildings").transform.GetChild(0).gameObject;
        playerBuildings.GetComponent<objectStats>().health += healthIncrease;
        playerBuildings.GetComponent<townHall>().level++;
        playerBuildings.GetComponent<townHall>().selectTexture();
        GetComponent<Button>().interactable = false;
    }

    public void upgradeIncome()
    {
        if(GameObject.Find("goldCounter").GetComponent<currency>().gold < price)
        {
            Debug.Log("cant upgrade income");
            return;
        }
        GameObject.Find("goldCounter").GetComponent<currency>().gold -= price;
        GameObject playerBuildings = GameObject.Find("playerBuildings").transform.GetChild(0).gameObject;
        playerBuildings.GetComponent<townHall>().amountGiven += incomeIncrease;
        playerBuildings.GetComponent<townHall>().level++;
        playerBuildings.GetComponent<townHall>().selectTexture();
        GetComponent<Button>().interactable = false;
    }
}
