using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musclefinder : MonoBehaviour
{
    [SerializeField] Nodeclass currentSearchMode;
    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    Gridymanager gridymanager;
    
    private void Awake()
    {
       gridymanager = GetComponent<Gridymanager>();
    }
    void Start()
    {
        ExploreNeibours(); 
    }
    void ExploreNeibours()
    {

    }
    void Update()
    {
        
    }
}
