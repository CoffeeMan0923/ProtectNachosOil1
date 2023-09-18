using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookatenemy : MonoBehaviour
{
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
        }
        else
        {
            Attack(false);
            particale.gameObject.GetComponent<Collider>().enabled = true;
        }

    }
    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
        
    }
}
