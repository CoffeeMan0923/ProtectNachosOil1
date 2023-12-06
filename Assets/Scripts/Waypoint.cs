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
    public Oiler Oilboy;
    public Oiler Ballonist;
    public Oiler OilboyGhost;
    public Oiler BallonistGhost;
    public Oiler OilboyGhostRed;
    public Oiler BallonistGhostRed;
    SoundManager soundmanager;
    Waypoint waypoint;
    public bool isballonist;
    public bool isoiler;
    public bool isPlaced;
    bool hovering;
    bool timer;
    bool isclick;
    void Start()
    {
        tissyselect = FindObjectOfType<Tissieselect>();
        soundmanager = FindObjectOfType<SoundManager>();
    }
    void Update()
    {
        if (!timer && hovering && !isclick)
        {
            isclick = isPlaced;
            timer = true;
            Invoke("SpawnGhost", 0.09f);
        }
        else if (!timer && hovering && isclick)
        {
            Invoke("SpawnGhostRed", 0.09f);
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
            if (isoiler)
            {
                OilboyGhost.CreateOiler(OilboyGhost, gameObject.transform.position);
                waypoint.isPlacable(isPlaced);

            }
            if (isballonist)
            {
                BallonistGhost.CreateOiler(BallonistGhost, gameObject.transform.position);
                waypoint.isPlacable(isPlaced);
            }
        }
        
    }
    void SpawnGhostRed()
    {
        if (hovering)
        {
            timer = false;
            if (isoiler)
            {
                OilboyGhostRed.CreateOiler(OilboyGhostRed, gameObject.transform.position);
                waypoint.isPlacable(isPlaced);

            }
            if (isballonist)
            {
                BallonistGhostRed.CreateOiler(BallonistGhostRed, gameObject.transform.position);
                waypoint.isPlacable(isPlaced);
            }
        }

    }
    void OnMouseDown()
    {
        isclick = isPlaced;
        if (isPlaced==false)
        {
            summonTissy();
        }
    }
}
