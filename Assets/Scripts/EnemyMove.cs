using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0,7)] float  speed = 1f;
    [SerializeField] int reward = 25;
    float originalspeed;
    // Start is called before the first frame update
    Enemy enemy;
    void Start()
    {
        originalspeed = speed;
        FindPath();
        StartCoroutine( printwatpoint());
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        speed = speed - 0.01f;
    }
    void OnTriggerStay(Collider other)
    {
        speed = speed - 0.001f;
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
