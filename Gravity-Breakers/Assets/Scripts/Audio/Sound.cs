using System;
using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class Sound
{
    public String name;
    
    public AudioClip clip;
    [Range(0f,1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;

    public bool loop;
    
    public AudioSource source;
}
