using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CallGordomRamsy : MonoBehaviour
{
    Oiler oiler;
    [SerializeField] GameObject GordomRamsy;
    [SerializeField] float HellStormdelay;
    SoundManager soundManager;
    bool Delay1;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        soundManager.PlayJustDoItManSapwanSounds();
    }
    void callHellsStorm()
    {
        oiler = FindObjectOfType<Oiler>();
        if(oiler != null)
        {
            Instantiate(GordomRamsy.gameObject, oiler.transform.position, Quaternion.identity);
        }
        Delay1 = false;
    }
    void sounddelay()
    {
        soundManager.PlayJustDoIt();
    }
    void Update()
    {
        if(Delay1 == false)
        {
            Delay1 = true;
            Invoke("callHellsStorm",HellStormdelay);
            Invoke("sounddelay", HellStormdelay - 1); 
        }
    }
}
