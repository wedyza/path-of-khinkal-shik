using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    Player player;
    private Image imgObj;
    void Start()
    {
        imgObj = GetComponent<Image>();
        player = FindObjectOfType<Player>();
        imgObj.sprite = player.backgrounds[player.currentBackgroundIndex];
    }
}
