using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoom : MonoBehaviour
{
    public GameObject movingHandle;
    public float speed = 0.1f;
    private Quaternion Startrotation = Quaternion.Euler(0, 0, 90);
    public Quaternion rotation2 = Quaternion.Euler(90, 0, 0);
    public KeyCode rotateKey = KeyCode.L;
 
    // Update is called once per frame


    

    public void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            print (movingHandle.transform.rotation.eulerAngles.x);
            Startrotation = movingHandle.transform.rotation;
            StartCoroutine(RotateOverTime(Startrotation, rotation2, 1f / speed));
        }
    }
 
    IEnumerator RotateOverTime (Quaternion originalRotation, Quaternion finalRotation, float duration) {
        if (duration > 0f) {
            float startTime = Time.time;
            float endTime = startTime + duration;
            movingHandle.transform.rotation = originalRotation;
            yield return null;
            while (Time.time < endTime) {
                float progress = (Time.time - startTime) / duration;
                // progress will equal 0 at startTime, 1 at endTime.
                movingHandle.transform.rotation = Quaternion.Slerp (originalRotation, finalRotation, progress);
                yield return null;
            }
        }
        movingHandle.transform.rotation = finalRotation;
    }
}
