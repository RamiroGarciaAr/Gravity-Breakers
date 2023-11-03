using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensitivityX;
    public float sensitivityY;

    public Transform orientatrion;

    private float xRotation;
    private float yRotation;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivityY * Time.deltaTime;
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Math.Clamp(xRotation, -90f, 90f);
        
        transform.rotation = Quaternion.Euler(xRotation,yRotation,0f);
        orientatrion.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
