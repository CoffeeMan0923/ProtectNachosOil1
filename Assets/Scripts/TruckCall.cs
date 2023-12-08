using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckCall : MonoBehaviour
{
    CallCenter callCenter;
    // Start is called before the first frame update
    void Start()
    {
        callCenter = FindObjectOfType<CallCenter>();
        callCenter.NewCaller();

    }

}
