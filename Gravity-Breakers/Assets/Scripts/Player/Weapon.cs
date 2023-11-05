using DG.Tweening;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    public Transform gunBarrel;
    public float bulletSpeed;
    public float dmg = 10;
    public Camera fpsCam;
    
    public GameObject Bullet;
    public Animator anim;

    public ParticleSystem muzzleFlash;
    public ParticleSystem casings;
    public GameObject hitEffect;
    
    public KeyCode reloadKey = KeyCode.R;
    public Image hitMarker;
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
        muzzleFlash.Play();
        casings.Play();
        RaycastHit hit;
        RecoilFire();
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                
                hitMarker.gameObject.SetActive(true);
                Invoke(nameof(ResetHitMarker),0.1f);
                EnemyHealth hp = hit.transform.gameObject.GetComponent<EnemyHealth>();
                hp.getHit(dmg);
                
            }

            var impact =Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            impact.GetComponent<hitParticles>().sparklyWine();
            
            Destroy(impact,2f);
        }
    

    }

    private void ResetHitMarker()
    {
        hitMarker.gameObject.SetActive(false);
    }

    void RecoilFire()
    {
        fpsCam.DOShakeRotation(0.1f,new Vector3(recoilX,Random.Range(-recoilY,recoilY),Random.Range(-recoilY,recoilY)),1,90f,false,ShakeRandomnessMode.Harmonic);
    }
}
