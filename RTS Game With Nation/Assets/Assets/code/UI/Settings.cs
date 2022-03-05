using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    private static bool GameisPaused = false;
    private bool Vibration;
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
            GameObject.FindGameObjectWithTag("MusicB").SetActive(true);
            GameObject.FindGameObjectWithTag("MusicA").SetActive(false); 
            }
          
        else {
            Music = true;
            GameObject.FindGameObjectWithTag("MusicB").SetActive(false); 
            GameObject.FindGameObjectWithTag("MusicA").SetActive(true); 
            
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
