using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGame : MonoBehaviour
{
    private Sounds sounds;
    public GameObject panel;

    public AudioClip clip;
    void Start()
    {
        sounds = GameObject.FindWithTag("sounds").GetComponent<Sounds>();
    }
    
    public void Continue()
    {
        sounds.Play(clip);
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
