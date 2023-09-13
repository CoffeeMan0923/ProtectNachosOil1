using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydamage : MonoBehaviour
{
    [SerializeField] int hp = 5;
    [SerializeField] int currenthp = 0;

    Enemy enemy;
    void OnParticleCollision(GameObject other)
    {
        currenthp--;
    }


    void Start()
    {
        enemy = GetComponent<Enemy>();
        currenthp = hp;
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
