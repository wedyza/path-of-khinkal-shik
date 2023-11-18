using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    [SerializeField] private GameObject go;
    [SerializeField] private string name;

    [SerializeField] private Product[] products;
    [SerializeField] public int price;
}
