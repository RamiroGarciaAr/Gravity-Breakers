using System;
using UnityEngine;
public class Turrets : MonoBehaviour
{
    public EnemyStats stats;
    public bool chase = false;
    public bool attacked;
    public GameObject Bullet;
    public float bulletSpeed = 22f;
    public Transform gunBarrel;

    public KeyCode dmg = KeyCode.K;
    private void Start()
    {
        stats.player = GameObject.FindGameObjectWithTag("Player");
        stats.hp = 100;
        //stats.dmg = 2;
    }
    
    public void death()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if(chase) Invoke(nameof(shootAtPlayer),2f);
        if(Input.GetKeyDown(dmg))
        {
            death();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            getHit();
        }
    }

    private void shootAtPlayer()
    {
        gunBarrel.transform.LookAt(stats.player.transform);
        
        if (!attacked)
        {
            Rigidbody rb = Instantiate(Bullet,gunBarrel.transform.position,Quaternion.identity).GetComponent<Rigidbody>(); 
            rb.AddForce(gunBarrel.transform.forward * bulletSpeed,ForceMode.Impulse);
                      
            Destroy(rb.gameObject,stats.timeToDestoy);

            attacked = true;
            Invoke(nameof(ResetAttack),3f);
        }
    }
    public void ResetAttack()
    {
        attacked = false;
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
        stats.hp -= 25f;
        if (stats.hp <= 0)
        {
            death();
        }
    }
}
