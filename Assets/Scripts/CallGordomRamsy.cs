using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CallGordomRamsy : MonoBehaviour
{
    TowerLoc oiler;
    [SerializeField] GameObject GordomRamsy;
    [SerializeField] float HellStormdelay;
    [SerializeField] Animator animator;
    SoundManager soundManager;
    bool Delay1;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        soundManager.PlayJustDoItManSapwanSounds();
    }
    void callHellsStorm()
    {
        oiler = FindObjectOfType<TowerLoc>();
        if(oiler != null)
        {
            Instantiate(GordomRamsy.gameObject, oiler.transform.position, Quaternion.identity);
        }
        Delay1 = false;
    }
    void sounddelay()
    {
        animator.Play("JustDoIt");
        Invoke("startMoving", 3);
        gameObject.GetComponent<EnemyMove>().speed = 0.001f;
        gameObject.GetComponent<EnemyMove>().inballonable = true;
        soundManager.PlayJustDoIt();
    }
    void startMoving()
    {
        gameObject.GetComponent<EnemyMove>().inballonable = false;
        gameObject.GetComponent<EnemyMove>().speed = 1f;
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
