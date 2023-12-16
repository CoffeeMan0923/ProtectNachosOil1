using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int reward = 25;
    [SerializeField] int takeoil = 25;
    Objectpool pool;
    Bank bank;
    // Start is called before the first frame update
    void Start()
    {
        pool = FindObjectOfType<Objectpool>();
        bank = FindObjectOfType<Bank>();
        pool.EnemyAmount++;
    }

    public void OilReward()
    {
        if(bank == null) { return; }
        bank.Deposit(reward);
    }

    public void StealOil()
    {
        if (bank == null) { return; }
        bank.Whithdraw(takeoil);
    }

    void Update()
    {
        
    }
}
