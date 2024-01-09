using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    TextMeshProUGUI text;
    int price = 100;
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        text.text = price.ToString();
    }
    public void Upgrade(string characteristic)
    {
        var ch = player.characteristics[characteristic];
        if ((ch.step > 0 && ch.current < ch.maximum || ch.step < 0 && ch.current > ch.maximum) && player.money >= price)
        {
            ch.current += ch.step;
            player.characteristics[characteristic] = ch;
            //Debug.Log(player.characteristics[characteristic].current);
            player.money -= price;
            price *= 2;
        }        
    }
}