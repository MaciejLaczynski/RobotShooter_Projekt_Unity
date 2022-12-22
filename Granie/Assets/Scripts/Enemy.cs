using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float attackRefreshRate = 3f;

    [SerializeField]
    private float attackRange = 2.2f;

    private Animator animator;
    private AggroDetection aggroDetection;
    private Health healthTarget;
    private Vector3 targetPosition;

    private float attackTimer;
    private float enemyDistance;


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetection_OnAggro;
    }

    private void AggroDetection_OnAggro(Transform target)
    {
        Health health = target.GetComponent<Health>();
        if (health != null)
        {
            healthTarget = health;
        }
    }

    private void Update()
    {
        if(healthTarget != null)
        {
            targetPosition = healthTarget.transform.position;
            attackTimer += Time.deltaTime;
            enemyDistance = Vector3.Distance(targetPosition, transform.position);
            if (enemyDistance < attackRange)
            {
                if (CanAttack())
                {
                    Attack();
                }
            }
        }
    }

    private bool CanAttack()
    {
        return attackTimer >= attackRefreshRate;
    }

    private void Attack()
    {
        GetComponentInChildren<Animator>().SetTrigger("Attack");
        attackTimer = 0;
        healthTarget.TakeDamage(1);
    }
}