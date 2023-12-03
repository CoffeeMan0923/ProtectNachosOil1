using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class EnemyMove : MonoBehaviour
{
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
    bool StopAuraSFX;
    float originalspeed;
    float ranspeed;
    int isballoned;
    Enemy enemy;
    void Start()
    {
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
            speed = speed - 0.005f;
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
            speed = speed - 0.005f;
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

    void Update()
    {
        if (StopAuraSFX)
        {
            Aura.loop = false;
        }
        if (speed <= 0)
        {
            Instantiate(particalexplo, pos.transform.position, Quaternion.identity);
            enemy.OilReward();
            Destroy(gameObject);
        }
    }
    void FindPath()
    {
        path.Clear();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach(GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
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
    IEnumerator printwatpoint()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startposition = transform.position;
            Vector3 endposition = waypoint.transform.position;
            float movepercent = 0f;
            transform.LookAt(endposition);
             while(movepercent < 1f)
            {
                movepercent += Time.deltaTime * speed;
                transform.position=Vector3.Lerp(startposition, endposition, movepercent);
                yield return new WaitForEndOfFrame();
            }
             
            
            
        }
        CabinEntersounds();
        enemy.StealOil();
        Destroy(gameObject);
    }

}
