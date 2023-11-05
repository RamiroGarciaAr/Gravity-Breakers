using System;
using UnityEngine;

public class HoverAnimation : MonoBehaviour
{

    public float amplitud = 2f;
    public float speed = 1f;
    public float range = 2f;

    public LayerMask whatIsGround;

    public float rayDistance;
    //public Transform hoverPoint;
    private void Update()
    {
        RaycastHit hit;
        Vector3 p = transform.position;
        if (Physics.Raycast(transform.position,Vector3.down,rayDistance,whatIsGround))
        {
            p.y = (amplitud * Mathf.Pow(Mathf.Cos(Time.time * speed),2 )) + range;
        }
        else
        {
            p.y =( amplitud * Mathf.Cos(Time.time * speed) ) + range;
        }
        
        transform.position = p;
    }
}
