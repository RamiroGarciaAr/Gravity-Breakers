using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Climbing : MonoBehaviour
{
    [Header("References")] 
    public Transform orientation;
    public Rigidbody rb;
    public LayerMask whatIsWall;
    
    

    [Header("Climbing")] 
    public float climbSpeed;
    public float maxClimbTime;

    private float climbTimer;
    private bool isClimbing;

    [Header("Detection")] 
    public float detectionLength;
    public float sphereCastRadius; 
    public float maxWallLookAngle;

    private float wallLookAngle;

    private RaycastHit frontWallHit;
    private bool hasWallInFront;

    private void Update()
    {
        wallCheck();
    }

    private void StateMachine()
    {
        if (hasWallInFront && Input.GetKey(KeyCode.W) && wallLookAngle < maxWallLookAngle)
        {
            if (!isClimbing && climbTimer > 0) StartClimbing();

            if (climbTimer > 0) climbTimer -= Time.deltaTime;
            if (climbTimer < 0) StopClimbing();
        }
        else
        {
            if (isClimbing) StopClimbing();
        }
    }

    private void wallCheck()
    {
        hasWallInFront = Physics.SphereCast(transform.position,sphereCastRadius,orientation.forward,out frontWallHit,detectionLength,whatIsWall);
    }

    private void StartClimbing()
    {
        isClimbing = true;
    }

    private void ClimbingMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);
    }

    private void StopClimbing()
    {
        isClimbing = false;

    }

}
