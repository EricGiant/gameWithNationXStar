using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickable : MonoBehaviour
{
    List<Transform> buttons = new List<Transform>();
    public int toEnable;
    void Start()
    {
        //find all 5 buttons
        for(int i = 0; i < 5; i++)
        {
            buttons.Add(GameObject.Find("rightButtons").transform.GetChild(i));
        }
    }
    void OnMouseDown()
    {
        //when clicked disable all objects and enable the 1 that has to be enabled
        foreach(Transform go in buttons)
        {
            go.gameObject.SetActive(false);
        }
        buttons[toEnable].gameObject.SetActive(true);
    }
}
