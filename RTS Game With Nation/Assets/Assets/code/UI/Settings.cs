using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    public GameObject MusicA,MusicB;
    private static bool GameisPaused = false;
    public static bool Vibration;
    private bool Music;
    public Text VibrationText;
    //allows you to turn of vibaration
    public void ChangeVibration(){
        if (Vibration == true){
            Vibration = false;
            VibrationText.text = "Vibration: Off";        
            Debug.Log("Vibration off");
        }
        else {
            Vibration = true;
            VibrationText.text = "Vibration: On";   
            Debug.Log("Vibration on");
        }
    }
    //Change between 2 songs
    public void ChangeMusic(){
        if (Music == true){
            Music = false;
            MusicB.SetActive(true);
            MusicA.SetActive(false); 
            }
          
        else {
            Music = true;
            MusicB.SetActive(false); 
            MusicA.SetActive(true); 
            
        }
    }
    //pauses game
    public void Pause(){
        if (GameisPaused)
        {
            Time.timeScale = 1f;
            GameisPaused = false;
        }
        else 
        {
            Time.timeScale = 0f;
            GameisPaused = true;
        }
    }
}
