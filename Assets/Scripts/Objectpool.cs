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
    [SerializeField] int enemystospawwn = 0;
    [SerializeField] GameObject[] enemys;
    [SerializeField] GameObject enemyprefab;
    [SerializeField] float sapwntimer = 1f;
    [SerializeField] TextMeshProUGUI TextRound;
    [SerializeField] TextMeshProUGUI TextNewRound;
    [SerializeField] FlotingText flotingTextScript;
    [SerializeField] FlotingText flotingTextScript2;
    [SerializeField] AudioClip[] roundNumSounds;
    [SerializeField] AudioClip RoundWord;
    [SerializeField] AudioSource source;
    private AudioClip Sound;
    SoundManager soundManager;
    Enemydamage enemydamage;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject GameUi;
    [SerializeField] GameObject MenuUi;
    public int EnemyAmount;
    bool som;
    bool time1;
    bool UnPauseNow;
    bool GamePaused;
    int morehp;
    int roundUpTo2 = 1;
    bool istime;
    int RoundSpawnNum = 0;

    public void PauseGame()
    {
        GamePaused = true;
        time1 = false;
    }

    public void UnPauseGame()
    {
        UnPauseNow = true;
    }
    void Start()
    {
        NewRoundSounds();
        soundManager = FindObjectOfType<SoundManager>();
        StartCoroutine(spwanenemy());
        RoundSpawnNum = 1;
    }
    IEnumerator spwanenemy()
    {
        while (enemystospawwn >= 0)
        {
            int e = Random.Range(0, enemys.Length-24+RoundSpawnNum);
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
                    Invoke("Repeat", 6);
         }
         SlowTime();
        }
        
        void NewRoundSounds()
        {
            source.PlayOneShot(RoundWord);
            Invoke("NumSounds",0.8f);
        }
        
        void NumSounds()
        {
           Sound = roundNumSounds[round];
           source.PlayOneShot(Sound);
        }
        void SlowTime()
        {
        if (Input.GetKey(KeyCode.F) && GamePaused != true)
        {
            Time.timeScale = 7;
        }
        else if(GamePaused != true)
        {
            Time.timeScale = 1;
        }  
        else if (GamePaused == true && time1 !=true)
        {
            time1 = true;
            GameUi.GetComponent<Canvas>().enabled = false;
            MenuUi.SetActive(true);
            Time.timeScale = 0f;
        }
        if (GamePaused && UnPauseNow)
        {
            GamePaused = false;
            MenuUi.SetActive(false);
            GameUi.GetComponent<Canvas>().enabled = true;
            UnPauseNow = false;
            Time.timeScale = 1;
        }
        
        }
        void Repeat()
        {
          
            round++;
            if(RoundSpawnNum != 24)
            {
                RoundSpawnNum++;
            }
            NewRoundSounds();
            TextRound.text = "" + round;
            BallonResistance = BallonResistance - 0.0001f;
            TextNewRound.text = "" + round;
            flotingTextScript.Flash();
            flotingTextScript2.Flash();
            roundTransition = false;
            enemystospawwn = roundenemies;
            roundenemies++;
            StartCoroutine(spwanenemy());
        }
    
}
