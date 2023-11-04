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
    public float rotSpeed = 10f;

    public KeyCode dmg = KeyCode.K;
    private void Start()
    {
        Debug.Log("Start");
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
        if (chase)
        {
            Vector3 dir = transform.position - stats.player.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(dir);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
            
            Invoke(nameof(shootAtPlayer),2f);
        }
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

    private void shootAtPlayer(){
        
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
