using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 public class Tissieselect : MonoBehaviour
{
    public Oiler[] tissyList;
    public Oiler selectedTissy;
    bool istissy;
    bool isballonist;
    int Character;
    Waypoint waypoint;

    public void SelectedOilboy()
    {
        selectedTissy = tissyList[0];
    }

    public void SelectedBallonist()
    {
        selectedTissy = tissyList[1];
    }
    
    public void summonTissy(int cordinatesx,int cordinatesz)
    {
        bool isPlaced = selectedTissy.CreateOiler(selectedTissy,new Vector3(cordinatesx,0,cordinatesz));
        waypoint.isPlacable(isPlaced);
    }
    void Update()
    {
        
    }
}
