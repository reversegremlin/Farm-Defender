using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    //tower parameters
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10;
    [SerializeField] ParticleSystem projectileParticle;

    public Waypoint baseWaypoint;

    //tower state

    Transform targetEnemy;

    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy) {
            objectToPan.LookAt(targetEnemy.position);
            FireAtEnemy();
        } else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var enemies = FindObjectsOfType<EnemyCollider>();
        if (enemies.Length == 0) { return; }

        Transform closestEnemy = enemies[0].transform;

        foreach (EnemyCollider enemy in enemies)
        {
            closestEnemy = GetClosest(closestEnemy, enemy.transform);
        }
        targetEnemy = closestEnemy;

    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distanceToA = Vector3.Distance(transform.position, transformA.position);
        var distanceToB = Vector3.Distance(transform.position, transformB.position);

        if (distanceToA < distanceToB)
        {
            return transformA;
        }

        return transformB;
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        } else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
