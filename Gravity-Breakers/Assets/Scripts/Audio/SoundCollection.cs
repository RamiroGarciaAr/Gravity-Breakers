using System;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class SoundCollection 
{
    public String collectionName;
    
    public AudioClip[] clipsInCollection;

    [Range(0f,1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;

    public AudioSource source;



    public AudioClip getClipFromCollection()
    {
        return clipsInCollection[Random.Range(0, clipsInCollection.Length)];
    }
}
