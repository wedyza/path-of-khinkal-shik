using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScreenSwitchButton : MonoBehaviour, IPointerClickHandler
{
    private Sounds sounds;
    
    public float moveDistance;
    public RectTransform firstTable;
    public RectTransform secondTable;
    public AudioClip clip;

    void Start()
    {
        sounds = GameObject.FindWithTag("sounds").GetComponent<Sounds>();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        sounds.Play(clip, volume:2f);
        MoveObject(firstTable);
        MoveObject(secondTable);
    }
    public void MoveObject(RectTransform table)
    {
        Vector3 currentPosition = table.anchoredPosition;
        Vector3 newPosition = new Vector3(currentPosition.x - moveDistance, currentPosition.y, currentPosition.z);
        table.anchoredPosition = newPosition;
    }
}
