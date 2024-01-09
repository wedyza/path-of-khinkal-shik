using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    Player player;
    public int index;
    public Image mask;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        switch (index)
        {
            case 0:
                mask.fillAmount = player.characteristics["maxNumberOfClients"].current/player.characteristics["maxNumberOfClients"].maximum; break;
            case 1:
                mask.fillAmount = (8 - 2 * (player.characteristics["intervalBetweenClients"].current - player.characteristics["intervalBetweenClients"].maximum)) / 8; break;
            case 2:
                mask.fillAmount = (12 - 2 * (player.characteristics["cookingTime"].current - player.characteristics["cookingTime"].maximum)) / 12; break;
            case 3:
                mask.fillAmount = player.characteristics["tips"].current / player.characteristics["tips"].maximum; break;
        }
    }
}
