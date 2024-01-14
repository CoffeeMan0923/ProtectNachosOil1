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
    [SerializeField] float startingTruckHp;
    CallCenter callCenter;
    [SerializeField] float currentTruckHp;
    [SerializeField] Animator animator;
    [SerializeField] GameObject Abouttogetademo;
    [SerializeField] GameObject OrderADemopakege;
    [SerializeField] GameObject ChinStolen;
    [SerializeField] Transform position;
    bool one;
    public int DudesinRange;
    public bool isinrange;
    bool StopAuraSFX;
    float originalspeed;
    float enemyhp;
    int isballoned;
    Enemy enemy;
    Vector3 originalPos;
    public bool timer;
    float movePercent;
    int random1;
    int random2;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        random1 = Random.Range(0,2);
        soundManager.TruckKnucklesSpawnLine(random1);
        if (random1 == 1)
        {
            OrderADemopakege.GetComponent<GroudText>().FlashG();
        }
        if (random1 == 0)
        {
            Abouttogetademo.GetComponent<GroudText>().FlashG();
        }
        callCenter = FindObjectOfType<CallCenter>();
        callCenter.KnucklesOnField++;
        currentTruckHp = startingTruckHp;
        originalPos = transform.position;
        originalspeed = speed;
        
        FindPath();
        StartCoroutine(printwatpoint());
        enemy = GetComponent<Enemy>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Enemydamage>() != null && collision.gameObject.tag != "Penguin")
        {
            enemyhp = collision.gameObject.GetComponent<Enemydamage>().currenthp;
            enemyhp = enemyhp / enemyhp;
            currentTruckHp = currentTruckHp - enemyhp;
        }
        else if(collision.gameObject.GetComponent<Enemydamage>() != null)
        {
            Instantiate(ChinStolen, position.transform.position, Quaternion.identity);
            //ChinStolen.GetComponent<GroudText>().FlashG();
            soundManager.PlayChinStolenSound();
            currentTruckHp = currentTruckHp - currentTruckHp + 1;
        }



    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Batista" || other.tag == "Penguin")
        {
            isinrange = false;
            animator.Play("Knuckles");
            speed = speed - speed;
            DudesinRange++;
            Invoke("runanim", 1);
            soundManager.PlayPakageSound();
        }



    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Batista" || other.tag == "Penguin")
        {
            DudesinRange--;
            
        }
    }
    void runanim()
    {
        DudesinRange--;
       // speed = originalspeed;
      //  timer = false;
      //  isinrange=false;
        //animator.Play("Run");
    }
    void Update()
    {
        if(currentTruckHp < 1 && one == false)
        {
            one = true;
            callCenter.KnucklesOnField--;
            Destroy(gameObject);
        }
        if (DudesinRange <= 0)
        {
            speed = 2;
           //timer = true;
           //Invoke("runanim", 0.5f);
        }
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
        callCenter.KnucklesOnField--;
        Destroy(gameObject);
    }

}
