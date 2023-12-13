using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Khinkali : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IPointerDownHandler
{
    private RectTransform _rectTransform;
    private Canvas _mainCanvas;
    private CanvasGroup _canvasGroup;
    private GameObject drag;
    private Vector2 lastPos;
    private Transform startParent;
    private Vector3 startPos;
    private int mouseDownEncounter;
    private Image imgObj;

    public Sprite sprite;

    void Start()
    {
        _mainCanvas = GetComponentInParent<Canvas>();
    }
    
    void Awake()
    {
        mouseDownEncounter = 0;
        ProductsIn = new List<Product>();
        IsCooked = false;
        drag = GameObject.FindWithTag("drag");
        _canvasGroup = GetComponent<CanvasGroup>();
        _rectTransform = GetComponent<RectTransform>();
        imgObj = GetComponent<Image>();
    }

    public List<Product> ProductsIn { get; set; }
    public bool IsCooked { get; set; }
    
    public void OnDrop(PointerEventData eventData)
    {
        Product product = eventData.pointerDrag.GetComponent<Product>();

        if (product != null && (product.productType == Product.ProductType.meat ||
                                product.productType == Product.ProductType.vegetable))
        {
            var type = product.productType;
            foreach (var p in ProductsIn)
            {
                if (p.productType == type)
                    return; // тут можно вызвать сообщение, что продукт такого типа уже находится внутри хинкали
            }
            
            product.Cut();
            ProductsIn.Add(product);
        
            var otherItemTransform = eventData.pointerDrag.transform;
            otherItemTransform.SetParent(transform);
            otherItemTransform.localPosition = Vector3.zero;
            switch (type)
            {
                case Product.ProductType.vegetable:
                    otherItemTransform.SetAsLastSibling();
                    break;
                case Product.ProductType.meat:
                    otherItemTransform.SetAsFirstSibling();
                    break;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        if (lastPos == _rectTransform.anchoredPosition)
        {
            _rectTransform.SetParent(startParent, false);
            _rectTransform.anchoredPosition = startPos;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
        lastPos = _rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = _rectTransform.anchoredPosition;
        startParent = _rectTransform.parent;
        gameObject.transform.SetParent(drag.transform);
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (IsCooked)
            return;
        mouseDownEncounter += 1;
        if (mouseDownEncounter == 2)
        {
            imgObj.sprite = sprite;
            transform.localScale = new Vector2(33f/78f, 34f/63f);
            IsCooked = true;
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                gameObject.name = "НАСТОЯЩАЯ ХИНКАЛИНА";
                Destroy(child.gameObject);
            }
        }
    }
}
