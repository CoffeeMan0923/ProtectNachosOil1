using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CallGordomRamsy : MonoBehaviour
{
    TowerLoc oiler;
    [SerializeField] GameObject GordomRamsy;
    [SerializeField] GameObject JustDoItText;
    [SerializeField] GameObject DoItText;
    [SerializeField] float HellStormdelay;
    [SerializeField] Animator animator;
    [SerializeField] Transform position;
    public int rannum;
    public int rannum2;
    [SerializeField] GameObject DontLeyYourDreamsText;
    [SerializeField] GameObject YesterdayYouSaidTomorrow;
    
    SoundManager soundManager;
    bool Delay1;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        rannum2 = Random.Range(0, 2);
        soundManager.PlayJustDoItManSapwanSounds(rannum2);
        if (rannum2 == 1)
        {
            YesterdayYouSaidTomorrow.GetComponent<GroudText>().FlashG();
        }
        if (rannum2 == 0)
        {
            DontLeyYourDreamsText.GetComponent<GroudText>().FlashG();
        }

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
        soundManager.PlayJustDoIt(rannum);
        if(rannum == 0)
        {
            Instantiate(JustDoItText,position.transform.position,Quaternion.identity);
        }
        if (rannum == 1)
        {
            Instantiate(DoItText, position.transform.position, Quaternion.identity);
        }
    }
    void startMoving()
    {
        gameObject.GetComponent<EnemyMove>().inballonable = false;
        gameObject.GetComponent<EnemyMove>().speed = 1f;
    }
    void Randomizesound()
    {
        rannum = Random.Range(0, 2);
    }
    void Update()
    {
        if(Delay1 == false)
        {
            Delay1 = true;
            Invoke("callHellsStorm",HellStormdelay);
            Invoke("sounddelay", HellStormdelay - 1);
            Invoke("Randomizesound", HellStormdelay - 2);
        }
    }
}
