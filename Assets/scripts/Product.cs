using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Product : Drag
{
    public bool isAviable;
    public ProductType productType;
    
    public override void OnBeginDrag(PointerEventData eventData)
    {
        var clone = Instantiate(gameObject, gameObject.transform.position, quaternion.identity);
        clone.transform.SetParent(transform.parent);
        clone.transform.localScale = gameObject.transform.localScale;
        clone.transform.SetAsFirstSibling();
        base.OnBeginDrag(eventData);
    }

    public enum ProductType
    {
        meat,
        dough,
        vegetable,
        drink
    }
}
