using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class BackgroundsShop : MonoBehaviour
{
    TextMeshProUGUI text;
    [SerializeField] int index;
    public UnityEngine.UI.Image imgObj;
    public Sprite unavailable;
    public Sprite active;
    public Sprite available;
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    void Update()
    {
        if (player.backgrounds[index].isAvailable)
        {
            {
                if (player.currentBackgroundIndex == index)
                    imgObj.sprite = active;
                else imgObj.sprite = available;
                text.text = "";
            }
        }
        else
        {
            imgObj.sprite = unavailable;
            text.text = player.backgrounds[index].price.ToString();
        }
    }
}
