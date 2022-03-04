using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectStats : MonoBehaviour
{
    //holds health for every object in the game
    public float health;
    public Vibrator vibrator;

    void Update()
    {
        if(health <= 0)
        {
            //checks if object has to cause vibration on death
            if(!(vibrator == null))
            {
                vibrator.Vibrate();
            }
            Destroy(gameObject);
        }
    }
}
