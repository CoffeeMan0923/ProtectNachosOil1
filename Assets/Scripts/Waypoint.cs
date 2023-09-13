using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Oiler oilerPrefab;

    [SerializeField] GameObject tower;
    public bool isplacable = true; 
    void OnMouseDown()
    {
        if (isplacable == true)
        {
             bool isPlaced=oilerPrefab.CreateOiler(oilerPrefab, transform.position);
            isplacable = !isPlaced;
        }
    }
}
