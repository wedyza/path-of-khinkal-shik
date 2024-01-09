using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    /*public float maxNumberOfClients;
    public float intervalBetweenClients;
    public float cookingTime;
    public float tips;*/
    public Dictionary<string, (float current, float maximum, float step)> characteristics;

    public int money;

    public List<Sprite> backgrounds;

    public int currentBackgroundIndex;

    void Start()
    {
        /*maxNumberOfClients = 1;
        intervalBetweenClients = 5;
        cookingTime = 7;
        tips = 0;*/
        characteristics = new Dictionary<string, (float current, float maximum, float step)>()
        {
            { "maxNumberOfClients", (current: 1, maximum: 3, step: 1) },
            { "intervalBetweenClients", (current: 5, maximum: 1.5f, step: -0.5f) },
            { "cookingTime", (current: 7, maximum: 1.5f, step: -0.5f) },
            { "tips", (current: 0, maximum: 10, step: 1) },
        };
        money = 0;
        currentBackgroundIndex = 0;
    }

    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}
