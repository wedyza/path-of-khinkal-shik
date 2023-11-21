using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonReadyDish : MonoBehaviour
{
    [SerializeField] private GameObject go;
    [SerializeField] private Dish targetDish;

    private List<Dish> localProducts; //продукты, которые уже лежат в неготовом блюде
    private int percentOfReadyness; // процент готовности
    
    
}
