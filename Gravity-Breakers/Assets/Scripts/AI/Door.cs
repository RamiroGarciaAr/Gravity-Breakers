using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Button bot;

    public void Update()
    {
        if (bot.open)
        {
            Destroy(gameObject);
        }
    }
}