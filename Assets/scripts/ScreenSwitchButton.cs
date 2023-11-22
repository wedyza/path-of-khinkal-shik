using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScreenSwitchButton : MonoBehaviour, IPointerClickHandler
{
    public float moveDistance;
    public RectTransform firstTable;
    public RectTransform secondTable;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click");
        MoveObject(firstTable);
        MoveObject(secondTable);
    }
    public void MoveObject(RectTransform table)
    {
        Debug.Log("moving");
        Vector3 currentPosition = table.anchoredPosition;
        Vector3 newPosition = new Vector3(currentPosition.x - moveDistance, currentPosition.y, currentPosition.z);
        table.anchoredPosition = newPosition;
    }
}
