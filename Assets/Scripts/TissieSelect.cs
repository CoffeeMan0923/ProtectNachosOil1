using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 public class Tissieselect : MonoBehaviour
{
    public Oiler Oilboy;
    public Oiler Ballonist;
    Waypoint waypoint;
    bool isballonist;
    bool isoiler;
    bool isPlaced = true;
    bool isPlaced2 = true;

    public void SelectedOilboy()
    {
        isoiler=true;
    }
    public void NotSelectedOilboy()
    {
        isoiler = false;
    }

    public void SelectedBallonist()
    {
        isballonist=true;
    }
    public void NotSelectedBallonist()
    {
        isballonist = false;
    }

    void Update()
    {
        if (!isPlaced && isPlaced2)
        {
            isPlaced2 = false;
        }
        if (!isPlaced2 && isPlaced)
        {
            isPlaced = false;
        }
    }
    public void summonTissy(int cordinatesx,int cordinatesz)
    {
        if (isoiler)
        {
            isPlaced = Ballonist.CreateOiler(Ballonist, new Vector3(cordinatesx,0,cordinatesz));
            waypoint.isPlacable(isPlaced);
        }
        if (isballonist)
        {
            isPlaced2 = Oilboy.CreateOiler(Oilboy, new Vector3(cordinatesx, 0, cordinatesz));
            waypoint.isPlacable(isPlaced);
        }
    }
}
