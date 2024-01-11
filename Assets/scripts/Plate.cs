using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

public class Plate : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private int _counter = 0;
    private Vector2 _lastPos;
    private Vector3 _startPos;
    private Transform _startParent;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private GameObject _drag;
    private Canvas _mainCanvas;
    private Plate _child;
    private bool _isMoved;
    public Plate example;

    void Start()
    {
        _mainCanvas = GetComponentInParent<Canvas>();
    }
    
    void Awake()
    {
        _isMoved = false;
        _drag = GameObject.FindWithTag("drag");
        _canvasGroup = GetComponent<CanvasGroup>();
        _rectTransform = GetComponent<RectTransform>();
    }
    
    public void PlaceOnPlate(Khinkali khinkalina)
    {
        var pos = _counter % 3;

        pos -= 1;
        
        var rand = new Random();

        khinkalina.transform.SetParent(transform);
        khinkalina.transform.localPosition = new Vector3(-10 * pos, -10 * pos + 10);
        khinkalina.gameObject.SetActive(true);
        khinkalina.GetComponent<CanvasGroup>().blocksRaycasts = false;
        _counter += 1;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
        _lastPos = _rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!_isMoved)
        {
            _child = Instantiate(example, transform.position, Quaternion.identity);
            _child.transform.SetParent(transform.parent);
            _child.transform.localScale = transform.localScale;
            _child.transform.SetAsLastSibling();
            _isMoved = true;
        }
        _startPos = _rectTransform.anchoredPosition;
        _startParent = _rectTransform.parent;
        gameObject.transform.SetParent(_drag.transform);
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        if (_lastPos == _rectTransform.anchoredPosition)
        {
            _rectTransform.SetParent(_startParent, false);
            _rectTransform.anchoredPosition = _startPos;
            Destroy(_child);
            _isMoved = false;
        }
    }
}
