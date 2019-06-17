using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 10;
    [SerializeField] ParticleSystem projectileParticle;

 
    void Update()
    {
        if (targetEnemy) {
        //    GameObject actualEnemy = targetEnemy.gameObject;
        //    Collider m_Collider;
        //    Vector3 m_Center;
            //Fetch the Collider from the GameObject
       //     m_Collider = actualEnemy.GetComponent<Collider>();
            //Fetch the center of the Collider volume
       //     m_Center = m_Collider.bounds.center;
            //Output this data into the console
       //     objectToPan.LookAt(m_Center);
            objectToPan.LookAt(targetEnemy.position);
            //transform.LookAt(target.renderer.bounds.center);

            FireAtEnemy();
        } else
        {
            Shoot(false);
        }
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
