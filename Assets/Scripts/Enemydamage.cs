using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydamage : MonoBehaviour
{

    Enemy enemy;
    SoundManager soundManager;
    [SerializeField] GameObject particalexplo;
    [SerializeField] GameObject pos;
    public float currenthp;
    [SerializeField] float roundHealth;
    [SerializeField] float oildamage = 1;
    [SerializeField] bool ispenguin;
    [SerializeField] bool isbatista;
    [SerializeField] bool isbully;
    Musiclocation music;
    Objectpool objectpool;
    public bool freshSpawn;
    public float startingHp = 5;
    void Start()
    {
        music = FindObjectOfType<Musiclocation>();
        objectpool = FindObjectOfType<Objectpool>();
        freshSpawn = true;
        soundManager = FindObjectOfType<SoundManager>();
        enemy = GetComponent<Enemy>();
        currenthp = currenthp + startingHp;
        Spawnsounds();

    }
    public void AddHp(int extrahp)
    {
        currenthp = currenthp + extrahp;
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
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Truck")
        {
            PlayDamageSound();
            currenthp = currenthp - 1000;
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
            if (isbully)
            {
                music.GetComponent<AudioSource>().volume = 1;
            }
            Instantiate(particalexplo, pos.transform.position,Quaternion.identity);
            objectpool.EnemyAmount--;
            Destroy(gameObject);
            enemy.OilReward();
        }
    }
}
