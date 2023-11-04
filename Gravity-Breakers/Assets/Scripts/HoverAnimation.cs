using System;
using UnityEngine;

public class HoverAnimation : MonoBehaviour
{

    public float amplitud = 9f;
    public float speed = 1.3f;
    //public Transform hoverPoint;
    private void Update()
    {
        Vector3 p = transform.position;
        p.y = amplitud * Mathf.Cos(Time.time * speed) + 0.9f;
        transform.position = p;
    }
}
