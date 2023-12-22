using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //if error replace prefabs Oilist,Ballonist from serializable to public
    Vector2 cordinates = new Vector2Int();
    Tissieselect tissyselect;
    public bool isplacable = true;
    public bool isplacable2 = true;
    public Oiler SellTower;
    public bool SellSelected;
    public Oiler Oilboy;
    public Oiler Ballonist;
    public Oiler TruckCaller;
    public Oiler TruckCallerGhost;
    public Oiler OilboyGhost;
    public Oiler BallonistGhost;
    public Oiler TruckCallerGhostRed;
    public Oiler OilboyGhostRed;
    public Oiler BallonistGhostRed;
    public Oiler XGhost;
    public GameObject GroundCrack;
    public int Hp;
    public int OldHp;
    public bool bullylimiter;
    SoundManager soundmanager;
    Waypoint waypoint;
    public bool isballonist;
    public bool isoiler;
    public bool istruckcaller;
    public bool isPlaced;
    bool hovering;
    bool timer;
    bool isclick;
    public bool moneymissing;
    public bool nomoney1;
    public bool nomoney2;
    public bool nomoney3;
    void Start()
    {
        tissyselect = FindObjectOfType<Tissieselect>();
        soundmanager = FindObjectOfType<SoundManager>();
    }
    void Update()
    {
        if (!timer && hovering)
        {
            isclick = isPlaced;
            timer = true;
            Invoke("SpawnGhost", 0.09f);
        }
        if (isPlaced == true)
        {
            nomoney1 = true;
            nomoney2 = true;
            nomoney3 = true;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ramsy")
        {
            Hp--;
            if(Hp <= 0)
            {
                GroundCrack.gameObject.SetActive(true);
            }
        }
        
    }
    public void isPlacable(bool isPlaced)
    {
    
    }
    
    public void summonTissy()
    {
        if (isoiler)
        {
            isPlaced = Oilboy.CreateOiler(Oilboy, gameObject.transform.position);
            waypoint.isPlacable(isPlaced);
            
        }
        if (istruckcaller)
        {
            isPlaced = TruckCaller.CreateOiler(TruckCaller, gameObject.transform.position);
            waypoint.isPlacable(isPlaced);

        }
        if (isballonist)
        {
            isPlaced = Ballonist.CreateOiler(Ballonist,gameObject.transform.position);
            waypoint.isPlacable(isPlaced);
        }
        isclick = isPlaced;
    }
    public bool Placed;
    private void OnMouseEnter()
    {
        hovering = true;
        isclick = isPlaced;
        if (!isclick)
        {
            SpawnGhost();
        }
        if (isclick)
        {
            Invoke("SpawnGhostRed", 0.0009f);
        }
    }
    private void OnMouseExit()
    {
        hovering = false;
    }
    void SpawnGhost()
    {
        if (hovering)
        {
            timer = false;
            if (isoiler && !nomoney1 && !isclick && Hp > 0)
            {
                OilboyGhost.CreateOiler(OilboyGhost, gameObject.transform.position);
                waypoint.isPlacable(isPlaced);

            }
            else if (isoiler)
            {
                OilboyGhostRed.CreateOiler(OilboyGhostRed, gameObject.transform.position);
                waypoint.isPlacable(isPlaced);
            }
            if(istruckcaller && !nomoney3 && !isclick && Hp > 0)
            {
                TruckCallerGhost.CreateOiler(TruckCallerGhost, gameObject.transform.position);
                waypoint.isPlacable(isPlaced);
            }
            else if(istruckcaller)
            {
                TruckCallerGhostRed.CreateOiler(TruckCallerGhostRed, gameObject.transform.position);
                waypoint.isPlacable(isPlaced);
            }
            if (isballonist && !nomoney2 && !isclick && Hp > 0)
            {
                BallonistGhost.CreateOiler(BallonistGhost, gameObject.transform.position);
                waypoint.isPlacable(isPlaced);
            }
            else if (isballonist)
            {
                BallonistGhostRed.CreateOiler(BallonistGhostRed, gameObject.transform.position);
                waypoint.isPlacable(isPlaced);
            }
            if (SellSelected)
            {
                XGhost.CreateOiler(XGhost, gameObject.transform.position);
                waypoint.isPlacable(isPlaced);
            }
        }
        
    }
    void SpawnGhostRed()
    {
        if (hovering)
        {
            timer = false;
            if (isoiler && nomoney1)
            {
                OilboyGhostRed.CreateOiler(OilboyGhostRed, gameObject.transform.position);
                waypoint.isPlacable(isPlaced);

            }
            if(istruckcaller && nomoney3)
            {
                TruckCallerGhostRed.CreateOiler(TruckCallerGhostRed, gameObject.transform.position);
                waypoint.isPlacable(isPlaced);
            }
            if (isballonist && nomoney2)
            {
                BallonistGhostRed.CreateOiler(BallonistGhostRed, gameObject.transform.position);
                waypoint.isPlacable(isPlaced);
            }
        }

    }
    void OnMouseDown()
    {
        isclick = isPlaced;
        if (isPlaced == false && Hp >= 1)
        {
            summonTissy();
        }
        if (SellSelected)
        {
            isPlaced = false;
            SellTower.CreateOiler(SellTower, gameObject.transform.position);

        }
    }
}