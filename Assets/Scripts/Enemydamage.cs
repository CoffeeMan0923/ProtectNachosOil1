using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydamage : MonoBehaviour
{
    [SerializeField] int startingHp = 5;
    [SerializeField] int currenthp = 0;

    Enemy enemy;
    Objectpool objectpool;
    void OnParticleCollision(GameObject other)
    {
        currenthp--;
    }


    void Start()
    {
        enemy = GetComponent<Enemy>();
        currenthp = currenthp + startingHp;
        roundhp(0);

    }
    public void roundhp(int round)
    {
        currenthp = currenthp + round - 1;
    }
    // Update is called once per frame
    void Update()
    {
        Destroyenemy();
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
