using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioSource _audioSource;

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }
    
    public void Play( AudioClip clip, float continious = 0f, float volume = 1f)
    {
        StartCoroutine(work(continious, volume, clip));
    }
    
    private IEnumerator work(float continious, float volume, AudioClip clip)
    {
        if (continious == 0f)
            _audioSource.PlayOneShot(clip, volume);
        else
        {
            _audioSource.PlayOneShot(clip, volume);
            yield return new WaitForSeconds(continious);
            _audioSource.Stop();
        }
    }
}
