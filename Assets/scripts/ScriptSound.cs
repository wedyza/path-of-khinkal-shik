using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSound : MonoBehaviour
{
    public AudioClip clip;

    private Sounds sounds;

    void Awake()
    {
        sounds = GameObject.FindWithTag("sounds").GetComponent<Sounds>();
    }

    public void PlayON()
    {
        sounds.Play(clip);
    }
}
