using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 public class Tissieselect : MonoBehaviour
{
    bool Oilboy;
    bool Ballonist;
    [SerializeField] GameObject parent;
    SoundManager soundManager;
    int mon;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        Oilboy = true;
        Ballonist = true;
    }
    public void Cash(int money)
    {
        mon = money;
        if (money < 75)
        {
            foreach (Transform child in parent.transform)
            {
                if (child.GetComponent<Waypoint>() != null && child.GetComponent<Waypoint>().isPlaced == false)
                {
                    child.GetComponent<Waypoint>().nomoney1 = true;

                }
            }
        }
        else
        {
            foreach (Transform child in parent.transform)
            {
                if (child.GetComponent<Waypoint>() != null && child.GetComponent<Waypoint>().isPlaced == false)
                {
                    child.GetComponent<Waypoint>().nomoney1 = false;

                }
            }
        }
        if(money < 150)
        {
            foreach (Transform child in parent.transform)
            {
                if (child.GetComponent<Waypoint>() != null && child.GetComponent<Waypoint>().isPlaced == false)
                {
                    child.GetComponent<Waypoint>().moneymissing = true;
                    child.GetComponent<Waypoint>().nomoney2 = true;

                }
            }
        }
        else
        {
            foreach (Transform child in parent.transform)
            {
                if (child.GetComponent<Waypoint>() != null && child.GetComponent<Waypoint>().isPlaced == false)
                {
                    child.GetComponent<Waypoint>().moneymissing = false;
                    child.GetComponent<Waypoint>().nomoney2 = false;

                }
            }
        }
    }
    public void OilboySelected()
    {
        if (soundManager != null)
        {
            soundManager.PlayCharacterButtonPresedSound();
        }
        Oilboy = true;
        Ballonist = false;
        Oilboyloop();
    }

    public void BallonistSelected()
    {
        if (soundManager != null)
        {
            soundManager.PlayCharacterButtonPresedSound();
        }
        Ballonist = true;
        Oilboy = false;
        Ballonistloop();

    }
    void Oilboyloop()
    {
        foreach (Transform child in parent.transform)
        {
            if(child.GetComponent<Waypoint>() != null)
            {
                print("Foreach loop: " + child);
                child.GetComponent<Waypoint>().isoiler = true;
                child.GetComponent<Waypoint>().isballonist = false;
            }
        }
            
       
    }
    void Ballonistloop()
    {
        foreach (Transform child in parent.transform)
        {
            if (child.GetComponent<Waypoint>() != null)
            {
                print("Foreach loop: " + child);
                child.GetComponent<Waypoint>().isoiler = false;
                child.GetComponent<Waypoint>().isballonist = true;
            }
        }


    }

    void Update()
    {
        Cash(mon);
    }


}
