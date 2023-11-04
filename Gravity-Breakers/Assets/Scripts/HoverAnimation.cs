using System;
using UnityEngine;

public class HoverAnimation : MonoBehaviour
{

    public float amplitud = 0.3f;
    public float speed = 1.3f;
    //public Transform hoverPoint;
    private void Update()
    {
        Vector3 p = transform.position;
        p.y = amplitud * Mathf.Cos(Time.time * speed) + 2.5f;
        transform.position = p;
    }
}
