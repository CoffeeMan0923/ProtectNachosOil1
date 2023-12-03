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
    SoundManager soundmanager;
    Waypoint waypoint;
    public bool isballonist;
    public bool isoiler;
    public bool isPlaced;
    void Start()
    {
        tissyselect = FindObjectOfType<Tissieselect>();
        soundmanager = FindObjectOfType<SoundManager>();
    }
    void Update()
    {

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
    }
    public bool Placed;
    void OnMouseDown()
    {
        if (isPlaced==false)
        {
            summonTissy();
        }
    }
}
