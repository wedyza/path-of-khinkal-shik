using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Themes : MonoBehaviour
{
    private Sounds _sounds;
    Player player;

    public AudioClip clip;
    void Start()
    {
        _sounds = GameObject.FindWithTag("sounds").GetComponent<Sounds>();
    }
    
    public void SwitchTheme(int themeIndex)
    {
        player = FindObjectOfType<Player>();
        if (!player.backgrounds[themeIndex].isAvailable && player.money >= player.backgrounds[themeIndex].price)
        {
            _sounds.Play(clip);
            player.money -= player.backgrounds[themeIndex].price;
            var b = player.backgrounds[themeIndex];
            b.isAvailable = true;
            player.backgrounds[themeIndex] = b;
        }
        if (player.backgrounds[themeIndex].isAvailable)
        {
            player.currentBackgroundIndex = themeIndex;
        }
    }
}
