using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using TMPro;
using Random = System.Random;
using UnityEngine.EventSystems;
using UnityEngine.U2D;

public class Order : MonoBehaviour, IPointerDownHandler
{
    private List<Product> _vegetables;
    private List<Product> _meats;
    private List<Product> _drinks;
    private List<Product> _groceries;
    private GameObject[] _people;

    private Product _chosenMeat;
    private Product _chosenVegetable1;
    private Product _chosenDrink;
    private Product _chosenGrocery;
    private GameObject _chosenPerson;
    private GameObject randomPerson;

    [SerializeField] GameObject tray;

    public bool IsSample;
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
        _people = GameObject.FindGameObjectsWithTag("person");
    }

    void Start()
    {
        if (IsSample)
        {
            IsSample = false;
            return;
        }
        
        Fill();
        var rnd = new Random();

        var randomMeat = ChooseProduct(_meats);
        _chosenMeat = Instantiate(randomMeat);
        var meatBox = transform.GetChild(0);
        _chosenMeat.transform.SetParent(meatBox);
        _chosenMeat.transform.localPosition = Vector3.zero;
        _chosenMeat.transform.localScale = randomMeat.transform.localScale;

        var randomVegetable = ChooseProduct(_vegetables);
        _chosenVegetable1 = Instantiate(randomVegetable);
        var vegetableBox = transform.GetChild(1);
        _chosenVegetable1.transform.SetParent(vegetableBox);
        _chosenVegetable1.transform.localPosition = Vector3.zero;
        _chosenVegetable1.transform.localScale = randomVegetable.transform.localScale;

        randomPerson = _people[new Random().Next(_people.Length)];
        randomPerson.tag = "personOnScene";
        _chosenPerson = Instantiate(randomPerson);
        var personBox = transform.GetChild(4);
        _chosenPerson.transform.SetParent(personBox);
        _chosenPerson.transform.localPosition = Vector3.zero;
        _chosenPerson.transform.localScale = randomVegetable.transform.localScale;
        
        
        if (rnd.Next(1, 3) * 2 - 3 > 0)
        {
            var randomDrink = ChooseProduct(_drinks);
            _chosenDrink = Instantiate(randomDrink);
            var drinkBox = transform.GetChild(2);
            _chosenDrink.transform.SetParent(drinkBox);
            _chosenDrink.transform.localPosition = Vector3.zero;
            _chosenDrink.transform.localScale = randomDrink.transform.localScale;
        }

        if (rnd.Next(1, 3) * 2 - 3 < 0)
        {
            var randomGrocery = ChooseProduct(_groceries);
            _chosenGrocery = Instantiate(randomGrocery);
            var groceryBox = transform.GetChild(3);
            _chosenGrocery.transform.SetParent(groceryBox);
            _chosenGrocery.transform.localScale = randomGrocery.transform.localScale;
            _chosenGrocery.transform.localPosition = Vector3.zero;
        }
    }

    Product ChooseProduct(List<Product> l) => l[new Random().Next(l.Count)];


    public void OnPointerDown(PointerEventData eventData)
    {
        if (IsEqual())
        {
            for (int i = 0; i < tray.transform.childCount; i++)
            {
                var child = tray.transform.GetChild(i);
                Destroy(child.gameObject);
            }
            randomPerson.tag = "person";
            _people = GameObject.FindGameObjectsWithTag("person");
            GameContoller.timeFromLastVisitor = 0;
            Destroy(gameObject);
        }
    }

    public bool IsEqual()
    {
        var correctDrink = false;
        var correctGrocery = false;
        //var correctKhinkali = new bool[];
        for (int i = 0; i < tray.transform.childCount; i++)
        {
            Product childProduct = tray.transform.GetChild(i).GetComponent<Product>();
            Khinkali childKhinkali = tray.transform.GetChild(i).GetComponent<Khinkali>();
            if (childProduct != null && childProduct.productType == Product.ProductType.drink)
                if (_chosenDrink != null)
                { 
                    if (childProduct.drinkType == _chosenDrink.drinkType && !correctDrink)
                        correctDrink = true;
                    else return false;
                }


            if (childProduct != null && childProduct.productType == Product.ProductType.grocery)
                if (_chosenGrocery != null)
                {
                    if (childProduct.groceryType == _chosenGrocery.groceryType && !correctGrocery)
                        correctGrocery = true;
                    else return false;
                }
            /*if (childKhinkali != null)
            {
                Debug.Log("childKhinkali");
            }*/
        }
        return correctDrink && correctGrocery;
    }
}
