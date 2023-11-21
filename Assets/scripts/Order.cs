using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using TMPro;

public class Order : MonoBehaviour, IDough
{
    [NonSerialized] List<Dish> _selectedDishes;
    [SerializeField] private List<Dish> dishes;
    public TextMeshProUGUI dish;
    public TextMeshProUGUI products;
    public GameObject gameObject;
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

    void Awake()
    {
        _selectedDishes = dishes;
        dish.text = _selectedDishes[0].name;
        products.text = Parse(_selectedDishes[0].products);
    }

    string Parse(Product[] products)
    {
        string answer = "";
        foreach (var i in products)
            answer += i.name + " ";
        return answer;
    }
}
