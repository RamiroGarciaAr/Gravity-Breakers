using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour
{

    [Header("Reference")] 
    public Transform orientation;
    public Transform playerObj;
    private Rigidbody rb;
    private PlayerMovement pm;


    [Header("Sliding")] 
    public float maxSlideTime;
    public float maxSlideForce;

    private float slideTimer;

    public float slideYScale;
    private float startYScale;

    [Header("Keybinds")] 
    public KeyCode slideKey = KeyCode.LeftControl;
    private float horizontalInput;
    private float verticalInput;

    public bool isSliding;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        startYScale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
        if (Input.GetKeyDown(slideKey) && (horizontalInput != 0 || verticalInput != 0))
            StartSlide();
        if (Input.GetKeyUp(slideKey) && isSliding)
            StopSlide();
    }

    private void FixedUpdate()
    {
        if (isSliding)
        {
            SlidingMovement();
        }

        
    }

    private void StartSlide()
    {
        isSliding = true;
        playerObj.localScale = new Vector3(playerObj.localScale.x, slideYScale, playerObj.localScale.z);
        rb.AddForce(Vector3.down *5f,ForceMode.Impulse);
        slideTimer = maxSlideTime;
    }
    private void SlidingMovement()
    {
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (!pm.OnSlope() || rb.velocity.y > 0)
        {
            rb.AddForce(inputDir.normalized * maxSlideForce,ForceMode.Force);
            slideTimer -= Time.deltaTime;
        }
        else
        {
            rb.AddForce(pm.GetSlopeMoveDir(inputDir)*maxSlideForce,ForceMode.Force);
        }

        
        if (slideTimer <= 0) StopSlide();
    }
    private void StopSlide()
    {
        isSliding = false;
        playerObj.localScale = new Vector3(playerObj.localScale.x, startYScale, playerObj.localScale.z);
    }
}
