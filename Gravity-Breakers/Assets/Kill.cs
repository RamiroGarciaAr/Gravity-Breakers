using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public playerHealth HP;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HP.health = -100000;
        }
    }
}
