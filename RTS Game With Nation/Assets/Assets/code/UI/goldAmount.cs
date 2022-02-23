using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goldAmount : MonoBehaviour
{
    currency currency;
    Text text;

    void Start()
    {
        currency = GetComponent<currency>();
        text = GetComponentInChildren<Text>();
    }

    void Update()
    {
        text.text = currency.gold.ToString();
    }
}
