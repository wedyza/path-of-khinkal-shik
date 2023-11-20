using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Product : MonoBehaviour, IFilling
{
    [SerializeField] private GameObject go;
    [SerializeField] private string name;
    bool isAviable;
}
