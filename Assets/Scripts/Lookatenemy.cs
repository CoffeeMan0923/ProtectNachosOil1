using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookatenemy : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float range = 15f;
    [SerializeField] Transform weapon;
    [SerializeField] GameObject particale;
    Transform target;
    bool attackLimiter = true;
    [SerializeField] bool isoilboy;
    [SerializeField] bool isballonist;
    [SerializeField] ParticleSystem projectileParticles;
    SoundManager soundManager;
    [SerializeField] float AttackSoundPerSecond = 2;
    

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
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
    void PlayAttackSound()
    {
        if (isballonist)
        {
            soundManager.BallonistAttack();
        }
        if (isoilboy)
        {
            soundManager.OilboyAttack();
        }
    }
    void PlayAnimationAttack()
    {
        if (isballonist)
        {
            animator.Play("Flex");
        }
        if (isoilboy)
        {
            animator.Play("ThrowOil");
        }
    }
    void PlayAnimationIdle()
    {
        if (isballonist)
        {
            animator.Play("RegularIdle");
        }
        if (isoilboy)
        {
            animator.Play("DwarfIdle");
        }
    }
    void AttackLimiter()
    {
        attackLimiter = true;
    }
    void Aimweapom()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);
        if (targetDistance < range)
        {

            Attack(true);
            particale.gameObject.GetComponent<Collider>().enabled = true;
            PlayAnimationAttack();
            if (attackLimiter && !isballonist)
            {
                attackLimiter = false;
                PlayAttackSound();
                Invoke("AttackLimiter", AttackSoundPerSecond);

            }
            else if (attackLimiter && isballonist)
            {
                attackLimiter = false;
                PlayAttackSound();
                Invoke("AttackLimiter", 0.1f);

            }

        }
        else
        {
            PlayAnimationIdle();
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
