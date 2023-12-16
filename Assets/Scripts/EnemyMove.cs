using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] bool isPenguin;
    SoundManager soundManager;
    [SerializeField] ParticleSystem Aura;
    [SerializeField] GameObject particalexplo;
    [SerializeField] GameObject pos;
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0,7)] float  speed = 1f;
    [SerializeField] int reward = 25;
    [SerializeField] float minSpeedRan = 0.5f;
    [SerializeField] bool moveRandom;
    [SerializeField] bool inballonable;
    [SerializeField] bool ispenguin;
    [SerializeField] bool isbatista;
    [SerializeField] float BallonistSlowRate = 0.005f;
    [SerializeField] bool DopathReverse;
    [SerializeField] bool isBully;
    [SerializeField] Animator animator;
    Objectpool objectpool;
    bool TakeCashLoop;
    bool AnimPlay;
    Bank bank;
    bool StopAuraSFX;
    float originalspeed;
    float ranspeed;
    int isballoned;
    public bool NewSpawn;
    Enemy enemy;
    Vector3 originalPos;
    float movePercent;
    void Start()
    {
        objectpool = FindObjectOfType<Objectpool>();
        bank = FindObjectOfType<Bank>();
        originalPos = transform.position;
        soundManager = FindObjectOfType<SoundManager>();
        if (moveRandom)
        {
            originalspeed = Random.Range(minSpeedRan, speed);
            speed = originalspeed;
        }
        else if (!moveRandom)
        {
            originalspeed = speed;
        }
        FindPath();
        StartCoroutine( printwatpoint());
        enemy = GetComponent<Enemy>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!inballonable)
        {
            Aura.loop = true;
            if (!Aura.isPlaying)
            {
                StopAuraSFX = false;
                Aura.Play();

            }
            isballoned++;
            speed = speed - BallonistSlowRate;
        }
        
    }
    void OnTriggerStay(Collider other)
    {
        if (!inballonable)
        {
            Aura.loop = true;
            StopAuraSFX = false;
            if (!Aura.isPlaying)
            {
                Aura.Play();

            }
            speed = speed - BallonistSlowRate;
        }
    }

    void OnTriggerExit(Collider other)
    {
        isballoned--;
        if (isballoned == 0)
        {
            StopAuraSFX = true;
            speed = originalspeed;
        }
    }
    public void AddBallonResistance(float extraresistance)
    {
        if (!isPenguin)
        {
            BallonistSlowRate = BallonistSlowRate + extraresistance;
        }
    }
    void Update()
    {
        if (AnimPlay)
        {
            animator.Play("Take");
        }
        if (TakeCashLoop)
        {
            TakeCashLoop = false;
            Invoke("TakeCash", 1);
        }
        if (StopAuraSFX)
        {
            Aura.loop = false;
        }
        if (speed <= 0)
        {
            objectpool.EnemyAmount--;
            Instantiate(particalexplo, pos.transform.position, Quaternion.identity);
            enemy.OilReward();
            Destroy(gameObject);
        }

        //transform.position = Vector3.Lerp(originalPos, path[path.Count - 1].transform.position, movePercent);
        //movePercent += Time.deltaTime * speed;
    }
    void FindPath()
    {
        path.Clear();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach(GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }

        for (int i = 0; i < path.Count - 1; i++)
            for (int j = 0; j < path.Count - i - 1; j++)
                if ((Int32.Parse(path[j].gameObject.name) > Int32.Parse(path[j + 1].gameObject.name)))
                {
                    var tempVar = path[j];
                    path[j] = path[j + 1];
                    path[j + 1] = tempVar;
                }
    }
    
    void CabinEntersounds()
    {
        if (ispenguin)
        {
            soundManager.PenguinCabinEnter();
        }
        if (isbatista)
        {
            soundManager.BatistaCabinEnter();
        }
        soundManager.CabinDamaged();
    }
    void TakeCash()
    {
        if (bank.currentBalance == 0)
        {
            objectpool.EnemyAmount--;
            Destroy(gameObject);
        }
        else
        {
            TakeCashLoop = true;
            bank.Whithdraw(25);
            soundManager.PlayMoneySpendSound();
        }
    }
    IEnumerator printwatpoint()
    {
        if (!isBully)
        {
            foreach (Waypoint waypoint in path)
            {
                Debug.Log(gameObject.name + " pos: " + waypoint.gameObject.name);
                Vector3 startposition = transform.position;
                Vector3 endposition = waypoint.transform.position;
                float movepercent = 0f;
                transform.LookAt(endposition);
                while (movepercent < 1f)
                {
                    movepercent += Time.deltaTime * speed;
                    transform.position = Vector3.Lerp(startposition, endposition, movepercent);
                    yield return new WaitForEndOfFrame();
                }


            }
        }
        else if (isBully)
        {
            foreach (Waypoint waypoint in path)
            {
                if(waypoint.gameObject.GetComponent<Waypoint>().bullylimiter != true)
                {
                    Debug.Log(gameObject.name + " pos: " + waypoint.gameObject.name);
                    Vector3 startposition = transform.position;
                    Vector3 endposition = waypoint.transform.position;
                    float movepercent = 0f;
                    transform.LookAt(endposition);
                    while (movepercent < 1f)
                    {
                        movepercent += Time.deltaTime * speed;
                        transform.position = Vector3.Lerp(startposition, endposition, movepercent);
                        yield return new WaitForEndOfFrame();
                    }
                }
            }
        }
        CabinEntersounds();
        enemy.StealOil();
        if (isBully != true)
        {
            objectpool.EnemyAmount--;
            Destroy(gameObject);
        }
        else
        {
            AnimPlay = true;
            animator.Play("Take");
            if(bank.currentBalance == 0)
            {
                objectpool.EnemyAmount--;
                Destroy(gameObject);
            }
            TakeCash();
        }
        
    }

}
