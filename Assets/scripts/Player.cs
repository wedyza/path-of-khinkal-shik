using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxNumberOfClients;
    public int intervalBetweenClients;

    public int cookingTime;

    public int tips;

    public int money;

    void Start()
    {
        maxNumberOfClients = 1;
        intervalBetweenClients = 5;
        cookingTime = 5;
        tips = 0;
        money = 0;
    }
}
