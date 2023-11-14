using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0,7)] float  speed = 1f;
    [SerializeField] int reward = 25;
    [SerializeField] float minSpeedRan = 0.5f;
    [SerializeField] bool moveRandom;
    [SerializeField] bool inballonable; 
    float originalspeed;
    float ranspeed;
    int isballoned;
    Enemy enemy;
    void Start()
    {
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
            isballoned++;
            speed = speed - 0.005f;
        }
        
    }
    void OnTriggerStay(Collider other)
    {
        if (!inballonable)
        {
            speed = speed - 0.005f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        isballoned--;
        if (isballoned == 0)
        {
            speed = originalspeed;
        }
    }

    void Update()
    {
        if (speed <= 0)
        {
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
        enemy.StealOil();
        Destroy(gameObject);
    }

}
