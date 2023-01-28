using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    DeathHandler deathHandler;
    // Start is called before the first frame update
    void Start()
    {
        deathHandler = GetComponent<DeathHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReduceHealth(int damage){
        health -= damage;
        if(health <= 0){
            deathHandler.HandleDeath();
        }
    }
}
