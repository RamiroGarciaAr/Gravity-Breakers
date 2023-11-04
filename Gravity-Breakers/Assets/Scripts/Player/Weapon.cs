using DG.Tweening;
using UnityEngine;
using DG.Tweening;

public class Weapon : MonoBehaviour
{

    public Transform gunBarrel;
    public float bulletSpeed;
    public float dmg = 10;
    public Camera fpsCam;
    
    public GameObject Bullet;
    public Animator anim;
    
    public KeyCode reloadKey = KeyCode.R;
    
    [Header("Recoil")] 
    [SerializeField] private float recoilX;
    [SerializeField] private float recoilY;
    [SerializeField] private float recoilZ;
    
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
        RecoilFire();
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                EnemyHealth hp = hit.transform.gameObject.GetComponent<EnemyHealth>();
                hp.getHit(dmg);
            }
        }
    

    }
    void RecoilFire()
    {
        fpsCam.DOShakeRotation(0.1f,new Vector3(recoilX,Random.Range(-recoilY,recoilY),Random.Range(-recoilY,recoilY)),1,90f,false,ShakeRandomnessMode.Harmonic);
    }
}
