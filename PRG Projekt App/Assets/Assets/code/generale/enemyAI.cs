using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    float waitTime = 5;
    unitBuilding[] unitBuildings;

    void Start()
    {
        unitBuildings = GameObject.Find("enemyBuildings").GetComponentsInChildren<unitBuilding>();
        StartCoroutine(AI());
    }
    // spawns random amount (4-7) of random units every set time
    IEnumerator AI()
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            waitTime = 7;
            Debug.Log("spawn wave");
            int spawnAmount = Random.Range(4, 8);
            for(int i = 0; i < spawnAmount; i++)
            {
                int whichBuilding = Random.Range(0, 3);
                int whichUnit = Random.Range(0, 2);
                if(whichUnit == 0)
                {
                    unitBuildings[whichBuilding].buyUnit1();
                }
                else
                {
                    unitBuildings[whichBuilding].buyUnit2();
                }
            }
        }
    }
}
