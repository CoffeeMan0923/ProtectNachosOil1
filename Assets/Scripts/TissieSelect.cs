using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class TissieSelect : MonoBehaviour
{
    public GameObject Oilist;
    public GameObject Ballonist;
    public GameObject Tissy;
    bool istissy;
    bool isballonist;
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
}
