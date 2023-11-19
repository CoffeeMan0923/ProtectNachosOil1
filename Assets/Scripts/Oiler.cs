using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oiler : MonoBehaviour
{
    [SerializeField] int cost = 75;
    [SerializeField] bool isBallonist;
    [SerializeField] bool isOilboy;
    SoundManager soundManager;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        Spawnsounds();
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
}
