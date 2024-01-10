using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

public class Plate : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private int counter = 0;
    
    public void PlaceOnPlate(Khinkali khinkalina)
    {
        var pos = counter % 3;

        pos -= 1;
        
        var rand = new Random();

        khinkalina.transform.SetParent(transform);
        khinkalina.transform.localPosition = new Vector3(-10 * pos, -10 * pos + 10);
        khinkalina.gameObject.SetActive(true);
        khinkalina.GetComponent<CanvasGroup>().blocksRaycasts = false;
        counter += 1;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
