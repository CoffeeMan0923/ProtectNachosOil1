using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 public class Tissieselect : MonoBehaviour
{

    [SerializeField] GameObject parent;
    SoundManager soundManager;
    int mon;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
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
        if (money < 100)
        {
            foreach (Transform child in parent.transform)
            {
                if (child.GetComponent<Waypoint>() != null && child.GetComponent<Waypoint>().isPlaced == false)
                {
                    child.GetComponent<Waypoint>().nomoney4 = true;

                }
            }
        }
        else
        {
            foreach (Transform child in parent.transform)
            {
                if (child.GetComponent<Waypoint>() != null && child.GetComponent<Waypoint>().isPlaced == false)
                {
                    child.GetComponent<Waypoint>().nomoney4 = false;

                }
            }
        }
        if (money < 150)
        {
            foreach (Transform child in parent.transform)
            {
                if (child.GetComponent<Waypoint>() != null && child.GetComponent<Waypoint>().isPlaced == false)
                {
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
                    child.GetComponent<Waypoint>().nomoney2 = false;

                }
            }
        }
        if (money < 500)
        {
            foreach (Transform child in parent.transform)
            {
                if (child.GetComponent<Waypoint>() != null && child.GetComponent<Waypoint>().isPlaced == false)
                {
                    child.GetComponent<Waypoint>().moneymissing = true;
                    child.GetComponent<Waypoint>().nomoney3 = true;

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
                    child.GetComponent<Waypoint>().nomoney3 = false;

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
        Oilboyloop();
    }
    public void NothingSelected()
    {
        NothingSelectedloop();
    }

    public void BallonistSelected()
    {
        if (soundManager != null)
        {
            soundManager.PlayCharacterButtonPresedSound();
        }
        Ballonistloop();

    }
    public void TruckCallerSelected()
    {
        if (soundManager != null)
        {
            soundManager.PlayCharacterButtonPresedSound();
        }
        TruckCallerLoop();

    }
    public void TowerSellerSelected()
    {
        if (soundManager != null)
        {
            soundManager.PlayCharacterButtonPresedSound();
        }
        SellTowerloop();
    }
    public void BlockFixerSelected()
    {
        if (soundManager != null)
        {
            soundManager.PlayCharacterButtonPresedSound();
        }
        BlockFixerLoop();
    }
    void NothingSelectedloop()
    {
        foreach (Transform child in parent.transform)
        {
            if (child.GetComponent<Waypoint>() != null)
            {
                print("Foreach loop: " + child);
                child.GetComponent<Waypoint>().isoiler = false;
                child.GetComponent<Waypoint>().isBlockFixer = false;
                child.GetComponent<Waypoint>().isballonist = false;
                child.GetComponent<Waypoint>().istruckcaller = false;
                child.GetComponent<Waypoint>().SellSelected = false;
            }
        }


    }
    void Oilboyloop()
    {
        foreach (Transform child in parent.transform)
        {
            if(child.GetComponent<Waypoint>() != null)
            {
                print("Foreach loop: " + child);
                child.GetComponent<Waypoint>().isoiler = true;
                child.GetComponent<Waypoint>().isBlockFixer = false;
                child.GetComponent<Waypoint>().isballonist = false;
                child.GetComponent<Waypoint>().istruckcaller = false;
                child.GetComponent<Waypoint>().SellSelected = false;
            }
        }
            
       
    }
    void SellTowerloop()
    {
        foreach (Transform child in parent.transform)
        {
            if (child.GetComponent<Waypoint>() != null)
            {
                print("Foreach loop: " + child);
                child.GetComponent<Waypoint>().isoiler = false;
                child.GetComponent<Waypoint>().isballonist = false;
                child.GetComponent<Waypoint>().istruckcaller = false;
                child.GetComponent<Waypoint>().SellSelected = true;
                child.GetComponent<Waypoint>().isBlockFixer = false;
            }
        }


    }
    void TruckCallerLoop()
    {
        foreach (Transform child in parent.transform)
        {
            if (child.GetComponent<Waypoint>() != null)
            {
                print("Foreach loop: " + child);
                child.GetComponent<Waypoint>().isoiler = false;
                child.GetComponent<Waypoint>().isballonist = false;
                child.GetComponent<Waypoint>().istruckcaller = true;
                child.GetComponent<Waypoint>().SellSelected = false;
                child.GetComponent<Waypoint>().isBlockFixer = false;
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
                child.GetComponent<Waypoint>().istruckcaller = false;
                child.GetComponent<Waypoint>().SellSelected = false;
                child.GetComponent<Waypoint>().isBlockFixer = false;
            }
        }


    }
    void BlockFixerLoop()
    {
        foreach (Transform child in parent.transform)
        {
            if (child.GetComponent<Waypoint>() != null)
            {
                print("Foreach loop: " + child);
                child.GetComponent<Waypoint>().isoiler = false;
                child.GetComponent<Waypoint>().isballonist = false;
                child.GetComponent<Waypoint>().istruckcaller = false;
                child.GetComponent<Waypoint>().SellSelected = false;
                child.GetComponent<Waypoint>().isBlockFixer = true;
            }
        }


    }

    void Update()
    {
        Cash(mon);
    }
}
