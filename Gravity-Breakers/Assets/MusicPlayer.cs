using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioManager am;

    public void Start()
    {
       am.PlaySingle("Music_Loop");
    }
}
