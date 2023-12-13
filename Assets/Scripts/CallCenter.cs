using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CallCenter : MonoBehaviour
{
    public bool StartSpawningTruckKnuckles;
    public bool timer1 = true;
    public bool timer2 = true;
    public bool timer3;
    public bool timer4;
    [SerializeField] GameObject button;
    [SerializeField] GameObject TruckKnuckles;
    SoundManager soundManager;
    bool CallEnsure;
    public int timeremaining = 50;
    public int time = 50;
    public int minustime = 10;
    public int Callers;
    public int oldCallersNum;
    public bool firstcall;
    public bool anotheone;
    public int KnucklesOnField;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Callers == 3)
        {
            button.GetComponent<Button>().enabled = false;
        }
        if (timer1 && StartSpawningTruckKnuckles && KnucklesOnField <= 0)
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
        if(anotheone == true)
        {
            if(KnucklesOnField <= 0 && anotheone == true)
            {
                anotheone = false;
                CallDelay();
            }
        }
    }
    void CallDelay()
    {

        if(KnucklesOnField <= 0)
        {
            timer1 = false;
            Invoke("CallTruckKnuckles", time);
            Invoke("CallSound", time - 5);
        }
        else
        {
            timer1 = false;
            anotheone = true;
        }

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
        
            anotheone = false;
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
        CancelInvoke("CallSound");
    }

}
