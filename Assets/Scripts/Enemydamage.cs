using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydamage : MonoBehaviour
{

    Enemy enemy;
    Objectpool objectpool;
    [SerializeField] float currenthp = 0;
    [SerializeField] float roundHealth;
    [SerializeField] float oildamage = 1;
    public float startingHp = 5;   
    int round;
    void OnParticleCollision(GameObject other)
    {
        currenthp = currenthp - oildamage;

        if(other.tag == "ballons")
        {

        }
    }


    void Start()
    {
        enemy = GetComponent<Enemy>();
        currenthp = currenthp + startingHp;
        currenthp--;

    }
    public void roundhp(int rounds)
    {
        currenthp = currenthp + rounds - 1;
    }
    // Update is called once per frame
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
