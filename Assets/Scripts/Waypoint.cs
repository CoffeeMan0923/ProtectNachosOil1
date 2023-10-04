using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    bool isoiler;
    bool isballonist;
    Oiler theprefab ;
    [SerializeField] Oiler oilerPrefab;
    [SerializeField] Oiler ballonistPrefab;
    bool isballonedselected;
    bool isoilboyselected;
    public bool isplacable = true;

    void Start()
    {
       theprefab = ballonistPrefab;
    }
    public void Oilboy(bool iswhat)
    {
        isoiler = iswhat;
        if (isoiler == true)
        {
            isoilboyselected = true;
            isballonedselected = false;
            theprefab = oilerPrefab;
        }
    }
    public void Ballonists(bool issomething)
    {
        isballonist = issomething;
        if (isballonist == true)
        {
            isoilboyselected = false;
            isballonedselected = true;
            theprefab = ballonistPrefab;
        }
    }
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        if (isplacable == true)
        {
             bool isPlaced=oilerPrefab.CreateOiler(theprefab, transform.position);
            isplacable = !isPlaced;
        }
    }
}
