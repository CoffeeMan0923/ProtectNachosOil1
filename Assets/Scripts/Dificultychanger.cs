using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dificultychanger : MonoBehaviour
{
    Objectpool pool;
    public int Numbtosetdif = 24;
    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
        ChangeDificulty(Numbtosetdif);
    }
    public void ChangeDificulty(float num)
    {
        Numbtosetdif = Convert.ToInt32(num);
        pool = FindObjectOfType<Objectpool>();
        if (pool == null)
        {
            pool = FindObjectOfType<Objectpool>();
        }
        else if (pool != null)
        {
            pool.dificulty = Numbtosetdif;
        }
    }
}
