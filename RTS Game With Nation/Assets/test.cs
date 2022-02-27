using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Sprite square;

    void Start()
    {
        Debug.Log(Physics.queriesHitTriggers);
    }
    void OnMouseDown()
    {
        Debug.Log("test");
        GameObject go = Instantiate(new GameObject());
        go.AddComponent<SpriteRenderer>().sprite = square;
    }
}
