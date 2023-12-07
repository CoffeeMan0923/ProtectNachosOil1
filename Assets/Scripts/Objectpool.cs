using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Objectpool : MonoBehaviour
{

    int round = 1;
    int roundenemies = 1;
    bool roundTransition = false;
    [SerializeField] int enemystospawwn = 2;
    [SerializeField] GameObject[] enemys;
    [SerializeField] GameObject enemyprefab;
    [SerializeField] float sapwntimer = 1f;
    [SerializeField] TextMeshProUGUI TextRound;
    Enemydamage enemydamage;
    bool istime;
    int Batistakin = 0;
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(spwanenemy());
        
    }
    IEnumerator spwanenemy()
    {
        while (enemystospawwn >= 0)
        {
            int e = Random.Range(0, enemys.Length-1+Batistakin);
            enemystospawwn--;
            Instantiate(enemys[e], transform);
            yield return new WaitForSeconds(sapwntimer);

        }
    }
        void Update()
        {

        if (!istime && round == 6)
        {
            istime = true;
            Batistakin = 1;
        }
        if (enemystospawwn <= -1)
            {
                if (roundTransition == false)
                {

                    roundTransition = true;
                    Invoke("Repeat", 5);
                }

            }
        }
        
        void Repeat()
        {
          
            round++;
            TextRound.text = "Round:" + round;
            roundTransition = false;
            enemystospawwn = roundenemies;
            roundenemies++;
            StartCoroutine(spwanenemy());
        }
    
}
