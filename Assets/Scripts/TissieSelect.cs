using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 public class TissieSelect : MonoBehaviour
{
    bool istissy;
    bool isballonist;
    int Character;
    Waypoint waypoint;

    public void SelectedOilboy()
    {
        Character = 0;
    }

    public void SelectedBallonist()
    {
        Character = 1;
    }
    
    void Update()
    {
        waypoint.SelectedCharacter(Character);
    }
}
