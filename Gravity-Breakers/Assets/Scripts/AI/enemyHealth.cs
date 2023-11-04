using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   private float health = 100f;

    public EnemyStats status;

    public void Start()
    {
        health = status.hp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            getHit(25f);
        }
    }
    private void death()
    {
        Destroy(gameObject);
    }
    public void getHit(float dmg)
    {
        health -= dmg;
        if (health == 0)
        {
            death();
        }
    }
}
