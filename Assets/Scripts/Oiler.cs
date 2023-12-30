using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oiler : MonoBehaviour
{       
    [SerializeField] int cost = 75;
    [SerializeField] bool isBallonist;
    [SerializeField] bool isOilboy;
    [SerializeField] bool isTruckCaller;
    [SerializeField] bool MakeSpawnSounds = true;
    [SerializeField] ParticleSystem OilExplosion;
    CallCenter callCenter;
    SoundManager soundManager;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        if (MakeSpawnSounds)
        {
            Invoke("Spawnsounds", 0.7f);
            moneyspenssound();
        }
        callCenter = FindObjectOfType<CallCenter>();
    }
    void Spawnsounds()
    {
        if (isBallonist)
        {
            soundManager.BallonistSpawn();
        }
        if (isOilboy)
        {
            soundManager.OilboySpawn();
        }
    }
    void moneyspenssound()
    {
        soundManager.PlayMoneySpendSound();
    }
    public bool CreateOiler(Oiler tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return false;
        }
        if (bank.CurrenBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Whithdraw(cost);
            return true;
        }

        return false;

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Sell")
        {
            Bank bank = FindObjectOfType<Bank>();
            if (isOilboy && !isTruckCaller)
            {
                bank.Deposit(50);
            }
            if (isBallonist)
            {
                bank.Deposit(75);
            }
            if (isTruckCaller)
            {
                callCenter.Callers--;
                bank.Deposit(250);
            }
            Destroy(gameObject);
        }
    }
}
