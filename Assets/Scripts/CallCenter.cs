using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CallCenter : MonoBehaviour
{
    public bool StartSpawningTruckKnuckles;
    public bool timer1 = true;
    public bool timer2 = true;
    public bool timer3;
    public bool timer4;
    [SerializeField] GameObject TruckKnuckles;
    SoundManager soundManager;
    bool CallEnsure;
    public int timeremaining = 50;
    public int time = 50;
    public int minustime = 10;
    public int Callers;
    public int oldCallersNum;
    public bool firstcall;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Callers > 3)
        {
            Callers = 3;
        }
        if (timer1 && StartSpawningTruckKnuckles)
        {
            timer1 = false;
            CallDelay();
        }
        if (oldCallersNum < Callers)
        {
            timeremaining = timeremaining - minustime;
            time = time - minustime;
            oldCallersNum = Callers;

        }
    }

    void CallDelay()
    {
        Invoke("CallTruckKnuckles", time);
        Invoke("CallSound", time - 5);
    }
    public void NewCaller()
    {
        StartSpawningTruckKnuckles = true;
        Callers++;
        if(firstcall == true)
        {
            Invoke("CallTruckKnuckles2", 4);
            Invoke("CallSound", 0);
            timer4 = false;
            firstcall = false;
        }
        
    }
    void CallTruckKnuckles()
    {
        timer1 = true;
        Instantiate(TruckKnuckles);
        soundManager.TruckKnucklesSpawnLine();
    }
    void CallTruckKnuckles2()
    {
        Instantiate(TruckKnuckles);
        soundManager.TruckKnucklesSpawnLine();
    }

    void CallSound()
    {
        soundManager.CallTruckKnuckles();
    }
    void CallCooldown()
    {
        timer4 = true;
    }
    void CancelCall()
    {
        CancelInvoke("CallTruckKnuckles");
    }

}
