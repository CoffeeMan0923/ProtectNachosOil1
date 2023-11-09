using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 public class Tissieselect : MonoBehaviour
{
    bool Oilboy;
    bool Ballonist;
    void Start()
    {
        parent = GameObject.FindGameObjectWithTag("Parentpath");
        Oilboy = true;
    }
    public void OilboySelected()
    {
        Oilboy = true;
        Ballonist = false;
    }

    public void BallonistSelected()
    {
        Ballonist=true;
        Oilboy=false;
    }
    List<Transform> GetAllChilds(Transform _t)
    {
        List<Transform> ts = new List<Transform>();

        foreach (Transform t in _t)
        {
            ts.Add(t);
            if (t.childCount > 0)
                ts.AddRange(GetAllChilds(t));
        }

        return ts;
    }

    void Update()
    {
        
    }


}
