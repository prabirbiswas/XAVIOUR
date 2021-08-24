using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject target;
    [SerializeField]
    float damage;
    float lastAttackTime = 0;
    float cooldown = 2;
    [SerializeField]
    float stoppingDistane;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position,target.transform.position);

        if(dist<stoppingDistane)
        {
            StopEnemy();
            Attack();
      
        }
        else
        {
            GoToTarget();
        }
        
    }

    private void GoToTarget()
    {
        agent.isStopped = false;

        agent.SetDestination(target.transform.position);
    }

    private void StopEnemy()
    {
        agent.isStopped = true;
    }

    private void Attack()
    {
        if (Time.time - lastAttackTime >= cooldown)
        {
            lastAttackTime = Time.time;
            target.GetComponent<CharacterStats>().TakeDamage(damage);
            target.GetComponent<CharacterStats>().CheckHealth();
        }
    }
}

