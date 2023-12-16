using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Objectpool : MonoBehaviour
{

    int round = 0;
    int roundenemies = 0;
    bool roundTransition = false;
    int hpboost;
    float BallonResistance;
    // enemystospawn was 2 incase of error
    [SerializeField] int enemystospawwn = 0;
    [SerializeField] GameObject[] enemys;
    [SerializeField] GameObject enemyprefab;
    [SerializeField] float sapwntimer = 1f;
    [SerializeField] TextMeshProUGUI TextRound;
    [SerializeField] TextMeshProUGUI TextNewRound;
    [SerializeField] FlotingText flotingTextScript;
    Enemydamage enemydamage;
    [SerializeField] GameObject parent;
    public int EnemyAmount;
    bool som;
    int morehp;
    int roundUpTo2 = 1;
    bool istime;
    int RoundSpawnNum = 0;

    void Start()
    {
        StartCoroutine(spwanenemy());
        RoundSpawnNum = 1;
    }
    IEnumerator spwanenemy()
    {
        while (enemystospawwn >= 0)
        {
            int e = Random.Range(0, enemys.Length-20+RoundSpawnNum);
            enemystospawwn--;
            Instantiate(enemys[e], transform);
            yield return new WaitForSeconds(sapwntimer);

        }
    }
        void Update()
        {
        if(round == roundUpTo2)
        {
            roundUpTo2 = roundUpTo2 + 2;
            morehp++;
            
        }
        foreach (Transform child in parent.transform)
        {
            if (child.GetComponent<Enemydamage>() != null && child.GetComponent<Enemydamage>().freshSpawn == true)
            {
                child.GetComponent<Enemydamage>().freshSpawn = false;
                child.GetComponent<Enemydamage>().AddHp(morehp - 1);
                child.GetComponent<EnemyMove>().AddBallonResistance(BallonResistance);
            }
        }

         if (!istime)
         {
             istime = true;
             RoundSpawnNum = 1;
         }
         if (enemystospawwn <= -1 && roundTransition == false && EnemyAmount == 0)
         {
            roundTransition = true;
                    Invoke("Repeat", 5);
         }

        }
        
        void Repeat()
        {
          
            round++;
            if(RoundSpawnNum != 20)
            {
                RoundSpawnNum++;
            }
            TextRound.text = "Round:" + round;
            BallonResistance = BallonResistance - 0.0001f;
            TextNewRound.text = "Round:" + round;
            flotingTextScript.Flash();
            roundTransition = false;
            enemystospawwn = roundenemies;
            roundenemies++;
            StartCoroutine(spwanenemy());
        }
    
}
