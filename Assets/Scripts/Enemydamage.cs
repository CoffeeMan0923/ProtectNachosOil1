using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydamage : MonoBehaviour
{
    int round;
    Objectpool objectpool;
    public float startingHp = 5;
    [SerializeField] float currenthp = 0;
    [SerializeField] float roundHealth;
    
    Enemy enemy;
   
    void OnParticleCollision(GameObject other)
    {
        currenthp--;

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
