using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Khinkali : Drag, IDish, IDropHandler
{
    void Awake()
    {
        Debug.Log("Im created");
        ProductsIn = new List<Product>();
        IsCooked = false;
    }

    public void AddProduct(Product  product)
    {
        ProductsIn.Add(product);
    }

    public List<Product> ProductsIn { get; set; }
    public bool IsCooked { get; set; }
    
    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        otherItemTransform.SetParent(transform);
        otherItemTransform.localPosition = Vector3.zero;
    }
}
