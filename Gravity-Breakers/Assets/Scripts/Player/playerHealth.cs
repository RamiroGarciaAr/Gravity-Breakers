using System;
using Unity.VisualScripting;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float health = 100f;
    public Transform start;
    private void Update()
    {
        if (health <= 0)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            getHit();
        }
    }

    private void getHit()
    {
        Debug.Log("ouch");
        health -= 25f;
    }
}
