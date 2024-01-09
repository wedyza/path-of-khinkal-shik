using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public TextMeshProUGUI text;
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        text.text = player.money.ToString();
    }
}
