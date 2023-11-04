using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitAnimation = null;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sparklyWine();
        }
    }

    public void sparklyWine()
    {
        hitAnimation.Play();
    }
}
