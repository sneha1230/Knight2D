using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        foreach (Sound item in sounds)
        {
            item.audioSource = gameObject.AddComponent<AudioSource>();
            item.audioSource.clip = item.audioClip;
            item.audioSource.volume = item.volume;
            item.audioSource.pitch = item.pitch;
            item.audioSource.loop = item.audioLoop;
        }
    }
    public void PlayAudio(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.audioName == name);
        if (s == null)
        {
            Debug.LogWarning("AudioName " + name + " not found");
            return;
        }
        s.audioSource.Play();
    }
    private void Start()
    {
        FindObjectOfType<AudioManager>().PlayAudio("Background");
    }

    public void SetVolume(String name, float volumeValue)
    {
        Sound s = Array.Find(sounds, Sound => Sound.audioName == name);
        if (s == null)
        {
            Debug.LogWarning("AudioName " + name + " not found");
            return;
        }
        else
        {
            s.audioSource.volume = volumeValue;
        }
    }
}
