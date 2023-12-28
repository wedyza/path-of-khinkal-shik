using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cutboard : Drop
{
    public Khinkali khinkali;
    private Khinkali created;
    
    public override void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        if (eventData.pointerDrag.CompareTag("dough"))
        {
            if (gameObject.transform.childCount > 0)
                return;
            created = Instantiate(khinkali);
            otherItemTransform = created.transform;
            created.transform.localScale /= 100;
        }
        else if (gameObject.transform.childCount > 0 && created != null)
        {
            created.OnDrop(eventData);
            return;
        }
        else
            return;
        otherItemTransform.SetParent(transform);
        otherItemTransform.localPosition = Vector3.zero;
    }
}
