using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxNumberOfClients;
    public int intervalBetweenClients;

    public int cookingTime;

    public int tips;

    public int money;

    public List<Sprite> backgrounds;

    public int currentBackgroundIndex;

    void Start()
    {
        maxNumberOfClients = 1;
        intervalBetweenClients = 5;
        cookingTime = 5;
        tips = 0;
        money = 0;
        currentBackgroundIndex = 0;
    }

    void Update()
    {
        DontDestroyOnLoad(gameObject);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(maxNumberOfClients);
            Debug.Log(cookingTime);
            Debug.Log(money);
        }
    }
}
