using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] int damage = 20;
    
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent(){
        if(target == null){
            return;
        }
        target.ReduceHealth(damage);
        Debug.Log("bang bang");
    }

}
