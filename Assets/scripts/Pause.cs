using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    private Sounds sounds;

    public AudioClip clip;
    
    void Start()
    {
        sounds = GameObject.FindWithTag("sounds").GetComponent<Sounds>();
    }
    public void PauseGame()
    {
        sounds.Play(clip);
        panel.SetActive(true);
        Time.timeScale = 0f;
    }
}
