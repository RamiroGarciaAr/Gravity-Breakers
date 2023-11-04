using DG.Tweening;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float dmg = 10;
    public Camera fpsCam;
    
    public GameObject Bullet;
    public Animator anim;

    public KeyCode reloadKey = KeyCode.R;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            anim.SetBool("isShooting", true);
        }
        if (Input.GetButtonUp("Fire1"))
            anim.SetBool("isShooting", false);

        if (Input.GetKeyDown(reloadKey))
        {
            
            anim.SetBool("isReloading",true);
        }
        if (Input.GetKeyUp(reloadKey))
            anim.SetBool("isReloading",false);
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                EnemyHealth hp = hit.transform.gameObject.GetComponent<EnemyHealth>();
                hp.getHit(dmg);
            }
        }


        //Rigidbody rb = Instantiate(Bullet,gunBarrel.transform.position,Quaternion.identity).GetComponent<Rigidbody>(); 
        //rb.AddForce(gunBarrel.transform.forward * bulletSpeed,ForceMode.Impulse);


    }
}
