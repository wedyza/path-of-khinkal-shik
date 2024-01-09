using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeButton : MonoBehaviour, IPointerClickHandler
{
    TextMeshProUGUI text;
    Player player;
    [SerializeField] string characteristic;
    void Start()
    {
        player = FindObjectOfType<Player>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        text.text = player.characteristics[characteristic].price.ToString();
    }
    public void Upgrade()
    {
        var ch = player.characteristics[characteristic];
        if ((ch.step > 0 && ch.current < ch.maximum || ch.step < 0 && ch.current > ch.maximum) && player.money >= player.characteristics[characteristic].price)
        {
            ch.current += ch.step;
            player.money -= player.characteristics[characteristic].price;
            ch.price *= 2;
            player.characteristics[characteristic] = ch;
        }        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Upgrade();
    }
}