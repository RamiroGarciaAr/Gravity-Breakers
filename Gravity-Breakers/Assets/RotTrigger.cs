using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotTrigger : MonoBehaviour
{
    public RotateRoom RotROOM;
    public GameObject room;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
