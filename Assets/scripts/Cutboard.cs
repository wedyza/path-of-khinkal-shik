using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cutboard : Drop
{
    public Khinkali khinkali;
    
    public override void OnDrop(PointerEventData eventData)
    {
        Transform otherItemTransform;
        Khinkali created = new Khinkali();
        otherItemTransform = eventData.pointerDrag.transform;
        Debug.Log("before if");
        if (eventData.pointerDrag.CompareTag("dough"))
        {
            Debug.Log("creating dish");
            if (gameObject.transform.childCount > 0)
            {
                Debug.Log("Уже готовится хинкалина ебаная");
                return;
            }
                created = Instantiate(khinkali);
                otherItemTransform = created.transform;
                created.transform.localScale /= 100;
        }
        else if (gameObject.transform.childCount > 0)
        {
            created.OnDrop(eventData);
            return;
        }
        Debug.Log("after if");
        otherItemTransform.SetParent(transform);
        otherItemTransform.localPosition = Vector3.zero;
    }
}
