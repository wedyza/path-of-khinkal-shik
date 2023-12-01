using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Interfaces;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Product : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public bool isAviable;
    public ProductType productType; 
    public Sprite sprite;

    private Image _imageObj;
    private bool _isCutted;
    private RectTransform _rectTransform;
    private Canvas _mainCanvas;
    private CanvasGroup _canvasGroup;
    private GameObject drag;
    private Vector2 lastPos;

    void Start()
    {
        _mainCanvas = GetComponentInParent<Canvas>();
    }
    
    void Awake()
    {
        drag = GameObject.FindWithTag("drag");
        _canvasGroup = GetComponent<CanvasGroup>();
        _rectTransform = GetComponent<RectTransform>();
        _imageObj = GetComponent<Image>();
        _isCutted = false;
        isAviable = true;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isAviable)
        {
            var clone = Instantiate(gameObject, gameObject.transform.position, quaternion.identity);
            clone.transform.SetParent(transform.parent);
            clone.transform.localScale = gameObject.transform.localScale;
            clone.transform.SetAsFirstSibling();
            isAviable = false;
        }
        gameObject.transform.SetParent(drag.transform);
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
        lastPos = _rectTransform.anchoredPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!_isCutted)
            _canvasGroup.blocksRaycasts = true;
        if (lastPos == _rectTransform.anchoredPosition)
            Destroy(gameObject);
    }

    public void Cut()
    {
        _imageObj.sprite = sprite;
        _isCutted = true;
    }

    public enum ProductType
    {
        meat,
        dough,
        vegetable,
        drink,
        grocery
    }
}
