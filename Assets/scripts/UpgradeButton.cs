using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    public void Upgrade(string characteristic)
    {
        var ch = player.characteristics[characteristic];
        if (ch.step > 0 && ch.current < ch.maximum || ch.step < 0 && ch.current > ch.maximum)
        {
            ch.current += ch.step;
            player.characteristics[characteristic] = ch;
            Debug.Log(player.characteristics[characteristic].current);
        }        
    }
}