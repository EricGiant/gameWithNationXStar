using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrator : MonoBehaviour
{
    //vibrates the phone
    public void Vibrate(){
        if(Settings.Vibration){
        Handheld.Vibrate();
        Debug.Log("Vibrating");
        }
    }
}
