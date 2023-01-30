using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    DisplayDamage displayDamage;
    PlayerHealth target;
    [SerializeField] int damage = 20;
    
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        displayDamage = FindObjectOfType<DisplayDamage>();
    }

    public void AttackHitEvent(){
        if(target == null){
            return;
        }
        target.ReduceHealth(damage);
        displayDamage.DisplayCanvas();
        Debug.Log("bang bang");
    }

}
