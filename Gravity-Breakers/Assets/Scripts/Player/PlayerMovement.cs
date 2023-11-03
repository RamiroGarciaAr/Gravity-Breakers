using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")] private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float groundDrag;
    public float slideSpeed;

    private float desiredMoveSpeed;
    private float lastDesierdMoveSpeed;


    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        sliding,
        air
    }

    [Header("Jump")] public float jumpForce;
    public float fallMultiplier = 2.5f;

    public int jumpCount = 2;
    private int jumpsLeft;

    public float thrusterMultiplier = 0.3f;
    public float normalAirMultiplier;
    private float airMultiplier;
    private bool readyToJump;

    [Header("Crouch")] public float crouchSpeed;
    [FormerlySerializedAs("crouchYSpeed")] public float crouchYScale;
    private float startYScale;

    [Header("Keybinds")] public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Ground Check")] public float playerHeight;
    public LayerMask whatIsGround;

    private bool isGrounded;
    private bool isOnPlatform;
    public Transform orientation;

    [Header("Slope Handeling")] public float maxSlopeAngle;
    private RaycastHit slopeHit;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    private Rigidbody rbPlatform;
    private Sliding sliding;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        sliding = GetComponent<Sliding>();
    }

    private void Start()
    {
        rb.freezeRotation = true;
        readyToJump = true;

        jumpsLeft = jumpCount;

        startYScale = transform.localScale.y;
    }


    private void Update()
    {
        // ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        // handle drag
        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        StateHandler();
    }

    private void StateHandler()
    {
        if (sliding.isSliding)
        {
            state = MovementState.sliding;

            if (OnSlope() && rb.velocity.y < 0.1f)
                desiredMoveSpeed = slideSpeed;
            else desiredMoveSpeed = sprintSpeed;
        }

        if (isGrounded && Input.GetKey(sprintKey) && !Input.GetKey(crouchKey))
        {
            state = MovementState.sprinting;
            desiredMoveSpeed = sprintSpeed;
        }
        else if (isGrounded && Input.GetKey(crouchKey) && !Input.GetKey(sprintKey))
        {
            state = MovementState.crouching;
            desiredMoveSpeed = crouchSpeed;
        }
        else if (isGrounded)
        {
            state = MovementState.walking;
            desiredMoveSpeed = walkSpeed;
        }
        else state = MovementState.air;

        if (Mathf.Abs(desiredMoveSpeed - lastDesierdMoveSpeed) > 4f && moveSpeed != 0)
        {
            StopAllCoroutines();
            StartCoroutine(SmoothlyLerpMoveSpeed());
        }
        else
        {
            moveSpeed = desiredMoveSpeed;
        }
        lastDesierdMoveSpeed = desiredMoveSpeed;
    }

    private IEnumerator SmoothlyLerpMoveSpeed()
    {
        float elapsedTime = 0;
        float difference = Mathf.Abs(desiredMoveSpeed - moveSpeed);
        float startValue = moveSpeed;

        while (elapsedTime < difference)
        {
            moveSpeed = Mathf.Lerp(startValue, desiredMoveSpeed, elapsedTime/ difference);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        moveSpeed = desiredMoveSpeed;
    }


    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && (jumpsLeft != 1 || isGrounded))
        {
            readyToJump = false;

            Jump();
        }

        if (Input.GetKeyUp(jumpKey))
        {
            readyToJump = true;
        }

        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.y);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.y);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Platform Enter");

            isGrounded = true;
            isOnPlatform = true;
            rbPlatform = other.gameObject.GetComponent<Rigidbody>();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Platform Exit");
            isGrounded = false;
            isOnPlatform = false;
            rbPlatform = null;
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (isGrounded)
        {
            jumpsLeft = jumpCount;
            airMultiplier = normalAirMultiplier;
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            Debug.Log(moveSpeed);
            //Debug.Log("Grounded");
        }

        if (OnSlope())
        {
            rb.AddForce(GetSlopeMoveDir(moveDirection) * moveSpeed * 20f,ForceMode.Force);
        }
        // in air
        else if (!isGrounded)
        {
            if (jumpsLeft == 1)
                airMultiplier = thrusterMultiplier;

            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            //Debug.Log("Not");
        }

        if (isOnPlatform)
        {
            rb.velocity = rb.velocity + rbPlatform.velocity;
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        jumpsLeft--;
        Debug.Log("Jumps:" + jumpsLeft);
    }

    public bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    public Vector3 GetSlopeMoveDir(Vector3 dir)
    {
        return Vector3.ProjectOnPlane(dir, slopeHit.normal).normalized;
    }

}