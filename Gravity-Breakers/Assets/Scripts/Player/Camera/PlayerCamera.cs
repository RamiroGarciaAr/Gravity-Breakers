using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerCamera : MonoBehaviour
{
    public float sensitivityX;
    public float sensitivityY;

    public Transform orientatrion;
    public Transform camHolder;
    
    private float xRotation;
    private float yRotation;

    private Camera _camera;
    private void Awake()
    {
        _camera = GetComponent<Camera>();
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
        
        camHolder.rotation = Quaternion.Euler(xRotation,yRotation,0f);
        orientatrion.rotation = Quaternion.Euler(0, yRotation, 0);

    }

    public void DoFOV(float endValue)
    {
        _camera.DOFieldOfView(endValue, 0.25f);
    }

    public void DoTilt(float zTilt)
    {
        transform.DOLocalRotate(new Vector3(0, 0, zTilt), 0.25f);
    }
}
