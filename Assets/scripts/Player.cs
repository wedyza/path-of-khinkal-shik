using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int maxNumberOfClients;
    [SerializeField] int intervalBetweenClients;

    [SerializeField] int cookingTime;

    [SerializeField] int tips;

    [SerializeField] int money;

    [SerializeField] public List<Dish> dishes;

    public Player()
    {
        maxNumberOfClients = 1;
        intervalBetweenClients = 5;
        cookingTime = 5;
        tips = 0;
        money = 0;
        dishes = new List<Dish>();
    }
}
