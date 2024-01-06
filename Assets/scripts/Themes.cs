using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Themes : MonoBehaviour
{
    Player player;
    public void SwitchTheme(int themeIndex)
    {
        player = FindObjectOfType<Player>();
        player.currentBackgroundIndex = themeIndex;
    }
}
