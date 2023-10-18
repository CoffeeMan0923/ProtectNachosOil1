using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookatenemy : MonoBehaviour
{
    public AudioClip[] sounds;
    AudioSource source;
    [SerializeField] Animator attack;
    [SerializeField] float range = 15f;
    [SerializeField] Transform weapon;
    [SerializeField] GameObject particale;
    Transform target;
    [SerializeField] ParticleSystem projectileParticles;
    

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = sounds[Random.Range(0, sounds.Length)];
        source.Play();
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
            attack.Play("attacks", 0, 0.0f);
            Attack(true);
            particale.gameObject.GetComponent<Collider>().enabled = true;
        }
        else
        {
            attack.Play("idel", 0, 0.0f);
            Attack(false);
            particale.gameObject.GetComponent<Collider>().enabled = false;
        }

    }
    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
        
    }
}
