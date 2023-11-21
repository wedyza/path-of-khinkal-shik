using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class Product : MonoBehaviour, IFilling, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    public bool isAviable;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin draggin");
        var clone = Instantiate(gameObject, gameObject.transform.position, quaternion.identity);
        clone.transform.SetParent(transform.parent);
        clone.transform.localScale = gameObject.transform.localScale;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end draggin");
        Destroy(gameObject);
    }
}
