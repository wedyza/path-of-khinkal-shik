using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    [SerializeField] private GameObject go;
    [NonSerialized] readonly List<Dish> _selectedDishes;
    [SerializeField] Player _player;

    public int Price
    {
        get
        {
            int sum = 0;
            foreach (Dish dish in _selectedDishes)
            {
                sum += dish.price;
            }

            return sum;
        }
    }

    public Order()
    {
        Debug.Log("А я работаю?");
        _selectedDishes = _player.dishes;
    }
    
    public void Start()
    {
    }
}
