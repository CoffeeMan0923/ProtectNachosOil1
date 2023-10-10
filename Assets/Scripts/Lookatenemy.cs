using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookatenemy : MonoBehaviour
{
    [SerializeField] Animator attack;
    [SerializeField] float range = 15f;
    [SerializeField] Transform weapon;
    [SerializeField] GameObject particale;
    Transform target;
    [SerializeField] ParticleSystem projectileParticles;
    

    void Start()
    {
       
    }

    void Update()
    {
        
        FindClosestTarget();
        Aimweapom();
    }
    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float MaxDistance = Mathf.Infinity;
        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            
            if(targetDistance < MaxDistance)
            {
                closestTarget = enemy.transform;
                MaxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }
    
    void Aimweapom()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);
        if(targetDistance < range)
        {
            Attack(true);
            particale.gameObject.GetComponent<Collider>().enabled = true;
        }
        else
        {
            Attack(false);
            particale.gameObject.GetComponent<Collider>().enabled = false;
        }

    }
    void Attack(bool isActive)
    {
        if (isActive)
        {
            attack.Play("ballons", 0, 0.0f);
        }
        else
        {
            attack.Play("breathingidle", 0, .0f);
        }
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
        
    }
}
