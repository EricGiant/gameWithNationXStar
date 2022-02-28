using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickable : MonoBehaviour
{
    List<Transform> buttons = new List<Transform>();
    public int toEnable;
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            buttons.Add(GameObject.Find("rightButtons").transform.GetChild(i));
        }
    }
    void OnMouseDown()
    {
        foreach(Transform go in buttons)
        {
            go.gameObject.SetActive(false);
        }
        buttons[toEnable].gameObject.SetActive(true);
    }
}
