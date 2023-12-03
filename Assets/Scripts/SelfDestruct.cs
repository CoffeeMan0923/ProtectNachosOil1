using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float Timebeforedestroyed = 5;
    void Start()
    {
        Invoke("SelfDestroy", Timebeforedestroyed);
    }
    void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
