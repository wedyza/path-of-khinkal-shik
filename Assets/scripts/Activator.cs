using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Activator : MonoBehaviour, IPointerDownHandler
{
    public Pot LinkedPot;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(LinkedPot.Boil());
    }
}
