using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    Animator enemyAnimator;
    Weapon weaponScript;
    bool isDead = false;
    public bool IsDead(){
        return isDead;
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        weaponScript = FindObjectOfType<Weapon>();
    }
    public void TakeDamage(int damage){
        BroadcastMessage("OnDamageTaken");
        health = health - damage;
        if(health <= 0){
            Die();
        }
    }
    void Die(){
        if(isDead) return;
        isDead = true;
        enemyAnimator.SetTrigger("isDead");
    }
    public void DestroyZombie(){
        Destroy(gameObject);
    }
    
}
