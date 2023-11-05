using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public AudioManager am;
    private float health = 100f;

    public EnemyStats status;
    private Animator anim;
    private float duration = 0.12f;
    public GameObject explosion;
    public void Awake()
    {
        anim = GetComponent<Animator>();
    }

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
        am.PlaySingle("Explotion");

        Instantiate(explosion);
        gameObject.SetActive(false);
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
