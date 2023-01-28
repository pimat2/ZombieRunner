using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    Weapon weaponScript;
    // Start is called before the first frame update
    void Start()
    {
        weaponScript = FindObjectOfType<Weapon>();
    }
    public void TakeDamage(int damage){
        health = health - damage;
        if(health <= 0){
            Destroy(gameObject);
        }
    }
}
