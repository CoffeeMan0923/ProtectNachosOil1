using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class TissieSelect : MonoBehaviour
{
    [SerializeField] bool isMrOil;
    [SerializeField] bool isMrBallons;
    bool isballonedselected;
    bool isoilboyselected;
    Waypoint waypoint;
    // Start is called before the first frame update
    void Start()
    {
        waypoint = FindObjectOfType<Waypoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        waypoint.Oilboy(isMrOil);

        waypoint.Ballonists(isMrBallons);

       
    }
}
