using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioSource _audioSource;

    public AudioClip audio;

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play(float continious = 0f, float volume = 1f)
    {
        StartCoroutine(work(continious, volume));
    }
    
    private IEnumerator work(float continious, float volume)
    {
        if (continious == 0f)
            _audioSource.PlayOneShot(audio, volume);
        else
        {
            _audioSource.PlayOneShot(audio, volume);
            yield return new WaitForSeconds(continious);
            _audioSource.Stop();
        }
    }
}
