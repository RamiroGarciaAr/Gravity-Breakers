using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float dmg = 10;
    public Transform gunBarrel;

    public GameObject Bullet;
    
    public float bulletSpeed;
    public 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Debug.Log("Bang!!");
        Rigidbody rb = Instantiate(Bullet,gunBarrel.transform.position,Quaternion.identity).GetComponent<Rigidbody>(); 
        rb.AddForce(gunBarrel.transform.forward * bulletSpeed,ForceMode.Impulse);
    }
}
