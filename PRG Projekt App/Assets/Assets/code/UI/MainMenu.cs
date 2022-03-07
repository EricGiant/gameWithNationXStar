using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void ChangeScene(int sceneNumber){
        StartCoroutine(gameScene(sceneNumber));
    }
    
    IEnumerator gameScene(int sceneNumber){
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneNumber, LoadSceneMode.Additive);
        while(!asyncLoad.isDone)
        {
            if(asyncLoad.progress <= 0.9f){
                Debug.Log("Loading Scene");
            }
            yield return null;                         
        }
        SceneManager.UnloadSceneAsync(currentScene);
    }
    public void EndGame(){
        Application.Quit();
    }
}
