using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    [SerializeField] float attackRange = 3f;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    Animator enemyAnimator;
    
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.stoppingDistance = attackRange;
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(isProvoked){
            EngagePlayer();
        }
        else if(distanceToTarget <= chaseRange){
            isProvoked = true;
        }
    }


    void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1,0,0);
        Gizmos.DrawWireSphere(transform.position, chaseRange); 
        Gizmos.color = new Color(0,1,0);
        Gizmos.DrawWireSphere(transform.position, attackRange); 
    }


    void EngagePlayer(){
        
        if(distanceToTarget >= navMeshAgent.stoppingDistance){
            ChaseTarget();
        }
        else if(distanceToTarget <= navMeshAgent.stoppingDistance){
            AttackTarget();
        }
    }


    void AttackTarget(){
        enemyAnimator.SetBool("Attack", true);
        
    }


    void ChaseTarget(){
        enemyAnimator.SetBool("Attack", false);
        enemyAnimator.SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

}
