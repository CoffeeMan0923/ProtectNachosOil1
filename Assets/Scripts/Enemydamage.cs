using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydamage : MonoBehaviour
{

    Enemy enemy;
    SoundManager soundManager;
    [SerializeField] float currenthp = 0;
    [SerializeField] float roundHealth;
    [SerializeField] float oildamage = 1;
    [SerializeField] bool ispenguin;
    [SerializeField] bool isbatista;
    public float startingHp = 5;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        enemy = GetComponent<Enemy>();
        currenthp = currenthp + startingHp;
        Spawnsounds();
        //currenthp--;

    }
    void Spawnsounds()
    {
        if (ispenguin)
        {
            soundManager.PenguinSpawn();
        }
        if (isbatista)
        {
            soundManager.BatistaSpawn();
        }
    }
    void PlayDamageSound()
    {
        if (ispenguin)
        {
            soundManager.PlayPenguinsound();
        }
        if (isbatista)
        {
            soundManager.PlayBatistasound();
        }
        soundManager.ImpactSound();
    }
    void OnParticleCollision(GameObject other)
    {
        currenthp = currenthp - oildamage;
        PlayDamageSound();

        if(other.tag == "ballons")
        {

        }
    }


    void Update()
    {
        Destroyenemy();
    }
    public void HealtIncrease(float round)
    {
        roundHealth = roundHealth * round;
        startingHp = startingHp + roundHealth;
    }

    void Destroyenemy()
    {
        if (currenthp <= 0)
        {
            Destroy(gameObject);
            enemy.OilReward();
        }
    }
}
