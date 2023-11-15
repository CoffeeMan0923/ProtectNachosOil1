using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gridymanager : MonoBehaviour
{
    [SerializeField] Vector2Int gridySize;
    Dictionary<Vector2Int, Nodeclass> grid = new Dictionary<Vector2Int, Nodeclass>();
    void Awake()
    {
        CreateGridy();
    }
    void CreateGridy()
    {
        for(int x = 0; x < gridySize.x; x++)
        {
            for (int y = 0; y < gridySize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Nodeclass(coordinates, true));
                Debug.Log(grid[coordinates].Coordinates + "_" + grid[coordinates].isWalkable);
            }       
        }
    }
}
