using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 public class Tissieselect : MonoBehaviour
{
    bool Oilboy;
    bool Ballonist;
    [SerializeField] GameObject parent;
    void Start()
    {
        Oilboy = true;
        Ballonist = true;
    }
    public void OilboySelected()
    {
        Oilboy = true;
        Ballonist = false;
        Oilboyloop();
    }

    public void BallonistSelected()
    {
        Ballonist=true;
        Oilboy=false;
        Ballonistloop();

    }
    void Oilboyloop()
    {
        foreach (Transform child in parent.transform)
        {
            print("Foreach loop: " + child);
            child.GetComponent<Waypoint>().isoiler = true;
            child.GetComponent<Waypoint>().isballonist = false;
        }
            
       
    }
    void Ballonistloop()
    {
        foreach (Transform child in parent.transform)
        {
            print("Foreach loop: " + child);
            child.GetComponent<Waypoint>().isballonist = true;
            child.GetComponent<Waypoint>().isoiler = false;
        }


    }

    void Update()
    {
        
    }


}
