using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TruckPath : MonoBehaviour
{
    SoundManager soundManager;
    [SerializeField] List<ReversePathLocation> path = new List<ReversePathLocation>();
    [SerializeField][Range(0, 7)] float speed = 1f;
    [SerializeField] int reward = 25;
    [SerializeField] float minSpeedRan = 0.5f;
    [SerializeField] bool moveRandom;
    [SerializeField] bool ispenguin;
    [SerializeField] bool isbatista;
    [SerializeField] float BallonistSlowRate = 0.005f;
    bool StopAuraSFX;
    float originalspeed;
    float ranspeed;
    int isballoned;
    Enemy enemy;
    Vector3 originalPos;
    float movePercent;
    void Start()
    {
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
        StartCoroutine(printwatpoint());
        enemy = GetComponent<Enemy>();
    }
    void Update()
    {
        if (speed <= 0)
        {
            enemy.OilReward();
            Destroy(gameObject);
        }

        //transform.position = Vector3.Lerp(originalPos, path[path.Count - 1].transform.position, movePercent);
        //movePercent += Time.deltaTime * speed;
    }
    void FindPath()
    {
        path.Clear();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("KnucklePath");

        foreach (GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<ReversePathLocation>());
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
    void OnCollisionEnter(Collision collision)
    {
        
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
        foreach (ReversePathLocation waypoint in path)
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
        Destroy(gameObject);
    }

}
