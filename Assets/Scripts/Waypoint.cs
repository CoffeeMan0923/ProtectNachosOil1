using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Oiler Oilist;
    public Oiler Ballonist;
    Oiler Tissy;
    bool istissy;
    bool isballonist;
    public bool isplacable = true;

    public void SelectedTissy()
    {
        istissy = true;
    }

    public void SelectedBallonist()
    {
        isballonist = true;
    }
    public void NotTissy()
    {
        istissy = false;
    }
    public void NotBallonist()
    {
        isballonist = false;
    }
    void Start()
    {
        Tissy = Oilist;
    }
    void Update()
    {
        if (istissy)
        {
            Tissy = Oilist;
        }
        else if (isballonist)
        {
            Tissy = Ballonist;
        }

    }
    void OnMouseDown()
    {
        if (isplacable == true)
        {
             bool isPlaced=Tissy.CreateOiler(Tissy, transform.position);
            isplacable = !isPlaced;
        }
    }
}
