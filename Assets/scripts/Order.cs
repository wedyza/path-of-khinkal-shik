using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using TMPro;
using Random = System.Random;

public class Order : MonoBehaviour
{
    private List<Product> _vegetables;
    private List<Product> _meats;
    private List<Product> _drinks;
    private List<Product> _groceries;

    private Product _chosenMeat;
    private Product _chosenVegetable1;
    private Product _chosenDrink;
    private Product _chosenGrocery;

    void Fill()
    {
        _vegetables = new List<Product>();
        _meats = new List<Product>();
        _drinks = new List<Product>();
        _groceries = new List<Product>();
        
        var products = GameObject.FindGameObjectsWithTag("product");

        foreach (var p in products)
        {
            var product = p.GetComponent<Product>();

            switch (product.productType)
            {
                case Product.ProductType.vegetable:
                    _vegetables.Add(product);
                    break;
                case Product.ProductType.drink:
                    _drinks.Add(product);
                    break;
                case Product.ProductType.meat:
                    _meats.Add(product);
                    break;
                case Product.ProductType.grocery:
                    _groceries.Add(product);
                    break;
            }
        }
    }

    void Awake()
    {
        Fill();
        var rnd = new Random();
        
        _chosenMeat = ChooseProduct(_meats);
        _chosenVegetable1 = ChooseProduct(_vegetables);

        if (rnd.Next(1, 3) * 2 - 3 > 0)
        {
            _chosenDrink = ChooseProduct(_drinks);
            Debug.Log(_chosenDrink.name);
        }

        if (rnd.Next(1, 3) * 2 - 3 < 0)
        {
            _chosenGrocery = ChooseProduct(_groceries);
            Debug.Log(_chosenGrocery.name);
        }

        Debug.Log(_chosenMeat.name + " " +  _chosenVegetable1.name);
        
    }

    Product ChooseProduct(List<Product> l) => l[new Random().Next(l.Count)];

    string Parse(Product[] products)
    {
        string answer = "";
        foreach (var i in products)
            answer += i.name + " ";
        return answer;
    }
}
