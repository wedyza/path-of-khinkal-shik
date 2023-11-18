using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    [SerializeField] private GameObject go;
    [SerializeField] List<Dish> dishes = new List<Dish>();
    [NonSerialized] readonly List<Dish> _selectedDishes;

    public int Price
    {
        get
        {
            int sum = 0;
            foreach (Dish dish in dishes)
            {
                sum += dish.price;
            }

            return sum;
        }
    }

    public Order()
    {
        Debug.Log("А я работаю?");
        _selectedDishes = dishes;
    }
    
    public void Start()
    {
    }
}
