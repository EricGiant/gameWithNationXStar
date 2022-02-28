using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectStats : MonoBehaviour
{
    public float health;
    public Vibrator vibrator;

    void Update()
    {
        if(health <= 0)
        {
            if(!(vibrator == null))
            {
                vibrator.Vibrate();
            }
            Destroy(gameObject);
        }
    }
}
