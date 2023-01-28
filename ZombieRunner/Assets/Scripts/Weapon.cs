using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] int damage = 10;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem muzzleSparks;

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }
    void Shoot(){
        ProcessRaycast();
        PlayMuzzleFlash();
    }
    void PlayMuzzleFlash(){
        muzzleSparks.Play();
        muzzleFlash.Play();
    }
    void ProcessRaycast(){
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)){
            Debug.Log("I hit this thing: " + hit.transform.name);
            //apply hit effect for visual feedback
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if(target == null) return; 
            target.TakeDamage(damage);
        }
        else{
            return;
        }
    }
}
