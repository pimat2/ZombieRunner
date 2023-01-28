using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        CalculateDistanceToPlayer();
    }
    void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1,0,0);
        Gizmos.DrawWireSphere(transform.position, chaseRange);    
    }
    void CalculateDistanceToPlayer(){
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(distanceToTarget <= chaseRange){
            ChasePlayer();
        }
    }
    void ChasePlayer(){
        navMeshAgent.SetDestination(target.position);
    }
}
