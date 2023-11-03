using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpeedUI : MonoBehaviour
{

    public TMP_Text speedCounter;
    public Rigidbody playerRb;

    // Update is called once per frame
    void Update()
    {
        speedCounter.text = GetVelocity().ToString();
    }

    private int GetVelocity()
    {
        return (int)Mathf.Sqrt(Mathf.Pow(playerRb.velocity.x,2)
                          + Mathf.Pow(playerRb.velocity.y,2)
                          + Mathf.Pow(playerRb.velocity.z,2));
    }
}
