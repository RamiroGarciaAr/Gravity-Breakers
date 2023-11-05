using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float health = 100f;

    public EnemyStats status;
    private Animator anim;
    private float duration = 0.12f;
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
        Destroy(gameObject);
    }
    public void getHit(float dmg)
    {
        anim.SetBool("takenDmg",true);
        Invoke(nameof(DisableAnim),duration);
        health -= dmg;
        if (health == 0)
        {
            death();
        }
    }

    private void DisableAnim()
    {
        anim.SetBool("takenDmg",false);
    }
}
