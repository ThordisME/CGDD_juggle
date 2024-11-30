using UnityEngine.Audio;
using UnityEngine;
using System;

// Note: followed this YouTube tutorial --> https://www.youtube.com/watch?v=6OT43pvUyfY 

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; // Array to hold all sounds

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.playOnAwake = false; // Prevents auto-play?
        }
    }

    public void Play(string name)
    {
        // Find the sound by name
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound: {name} not found!"); // safety
            return;
        }
        s.source.Play();
    }
}