using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bulletObj;
    public int timeToSpawn;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        Instantiate(bulletObj,this.transform);
        
    }
}
