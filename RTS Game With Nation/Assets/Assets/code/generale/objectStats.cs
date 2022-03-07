using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectStats : MonoBehaviour
{
    //holds health for every object in the game
    public float health;
    public Vibrator vibrator;
    public bool isTownhall;
    public GameObject vicScreen, defScreen;

    void Update()
    {
        if(health <= 0)
        {
            //checks if object has to cause vibration on death
            if(!(vibrator == null))
            {
                vibrator.Vibrate();
            }
            //checks if object is townhall when killed and then if victory/defeat screen has to pop up
            if(isTownhall)
            {
                //check is townhall is player
                //if it's player enable defeat screen
                //if enemy enable victory screen
                if(GetComponent<townHall>().isPlayer)
                {
                    defScreen.SetActive(true);
                }
                else
                {
                    vicScreen.SetActive(true);
                }
            }
            Destroy(gameObject);
        }
    }
}
