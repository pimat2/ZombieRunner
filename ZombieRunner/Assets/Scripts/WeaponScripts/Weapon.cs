using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] int damage = 10;
    [Header("Weapon and Hit VFX")]
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem muzzleSparks;
    [SerializeField] GameObject hitEffect;
    [Header("Weapon Characheristics")]
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float shotDelay = -0.5f;

    bool canShoot = true;
    void OnEnable() {
        canShoot = true;    
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canShoot == true){
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot(){
        canShoot = false;
        if(ammoSlot.GetCurrentAmmo(ammoType) > 0){
            ProcessRaycast();
            PlayMuzzleFlash();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(shotDelay);
        canShoot = true;
    }
    void PlayMuzzleFlash(){
        muzzleSparks.Play();
        muzzleFlash.Play();
    }
    void ProcessRaycast(){
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)){
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if(target == null) return; 
            target.TakeDamage(damage);
        }
        else{
            return;
        }
    }
    void CreateHitImpact(RaycastHit hit){
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
