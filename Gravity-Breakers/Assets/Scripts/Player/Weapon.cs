
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Collections;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    public Transform gunBarrel;
    public float bulletSpeed;
    public Camera fpsCam;

    [Header("Weapon Stats")]
    public float dmg = 10;
    public int maxAmmo = 10;
    public float reloadTime;
    private int currentAmmo =-1;
    public float fireRate = 100f;
    
    private float nextTimeToFire = 0f;
    private bool isReloading=false;
    [Header("Weapon Effects")]
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

    private void Start()
    {
        if (currentAmmo == -1)
            currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (anim.GetBool("isReloading")) return;
        
        if (Input.GetKeyDown(reloadKey))
        {
            StartCoroutine(Reload());
        }
      //  if (Input.GetKeyUp(reloadKey))
       //     anim.SetBool("isReloading",false);
        
        if (currentAmmo <= 0f)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            Debug.Log("BANG");
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            anim.SetBool("isShooting", true);
        }
        if (Input.GetButtonUp("Fire1"))
            anim.SetBool("isShooting", false);


    }

    IEnumerator Reload()
    {
        anim.SetBool("isReloading",true);
        yield return new WaitForSeconds(reloadTime);
        
        currentAmmo = maxAmmo;
        anim.SetBool("isReloading",false);
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        casings.Play();
        currentAmmo--;
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
