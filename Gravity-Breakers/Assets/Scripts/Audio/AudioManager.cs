using System;
using Unity.VisualScripting;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public SoundCollection[] soundCollections;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

    DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        foreach (SoundCollection collection in soundCollections)
        {
            collection.source = gameObject.AddComponent<AudioSource>();

            collection.source.pitch = collection.pitch;
            collection.source.volume = collection.volume;
        }
    }
    public void Start()
    {
        PlaySingle("Music_Loop");
    }
    public void PlaySingle(string name)
    {
       Sound s =  Array.Find(sounds, sound => sound.name == name);
       if (s == null)
       {
           Debug.LogWarning("Sound: " + name + " not found!");
       }

       s.source.Play();
    }

    private SoundCollection findSoundCollection(string nameOfCollection)
    {
        foreach (var c in soundCollections)
        {
            if (c.collectionName.Equals(nameOfCollection)) return c;
        }
        
        return null;
    }

    public void PlayCollection(string name)
    {
        SoundCollection c = findSoundCollection(name);
        if (c == null)
        {
            Debug.LogWarning("Sound Collection: " + name + " not found!");
        }

        c.source.clip = c.getClipFromCollection();
       
        c.source.Play();
    }
}
