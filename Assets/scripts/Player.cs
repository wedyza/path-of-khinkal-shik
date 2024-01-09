using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Dictionary<string, (float current, float maximum, float step, int price)> characteristics;

    public int money;

    public List<Sprite> backgrounds;

    public int currentBackgroundIndex;

    void Start()
    {
        characteristics = new Dictionary<string, (float current, float maximum, float step, int price)>()
        {
            { "maxNumberOfClients", (current: 1, maximum: 3, step: 1, price: 1) },
            { "intervalBetweenClients", (current: 5, maximum: 1.5f, step: -0.5f, price: 2) },
            { "cookingTime", (current: 7, maximum: 1.5f, step: -0.5f, price: 3) },
            { "tips", (current: 0, maximum: 10, step: 1, price: 4) },
        };
        money = 0;
        currentBackgroundIndex = 0;
    }

    void Update()
    {        
        if (GameObject.FindGameObjectsWithTag("player").Length == 1) DontDestroyOnLoad(gameObject);
    }
}
