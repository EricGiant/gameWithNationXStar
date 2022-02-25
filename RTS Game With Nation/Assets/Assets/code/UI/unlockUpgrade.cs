using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unlockUpgrade : MonoBehaviour
{
    public float price, healthIncrease;
    public int incomeIncrease;

    public void unlockMiniGun()
    {
        if(GameObject.Find("goldCounter").GetComponent<currency>().gold > price)
        {
            Debug.Log("cant buy minigun");
            return;
        }
        foreach(turretAI_V2 go in GameObject.Find("playerTurrets").GetComponentsInChildren<turretAI_V2>())
        {
            go.hasMiniGun = true;
        }
        GetComponent<Button>().interactable = false;
    }

    public void unlockCannon()
    {
        if(GameObject.Find("goldCounter").GetComponent<currency>().gold > price)
        {
            Debug.Log("cant buy cannon");
            return;
        }
        foreach(turretAI_V2 go in GameObject.Find("playerTurrets").GetComponentsInChildren<turretAI_V2>())
        {
            go.hasCannon = true;
        }
        GetComponent<Button>().interactable = false;
    }

    public void upgradeHealth()
    {
        if(GameObject.Find("goldCounter").GetComponent<currency>().gold > price)
        {
            Debug.Log("cant upgrade health");
            return;
        }
        GameObject.Find("playerBuildings").transform.GetChild(0).GetComponent<objectStats>().health += healthIncrease;
        GetComponent<Button>().interactable = false;
    }

    public void upgradeIncome()
    {
        if(GameObject.Find("goldCounter").GetComponent<currency>().gold > price)
        {
            Debug.Log("cant upgrade income");
            return;
        }
        GameObject.Find("playerBuildings").transform.GetChild(0).GetComponent<townHall>().amountGiven += incomeIncrease;
        GetComponent<Button>().interactable = false;
    }
}
