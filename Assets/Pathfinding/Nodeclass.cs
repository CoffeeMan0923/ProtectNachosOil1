using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Nodeclass
{
    public Vector2Int Coordinates= new Vector2Int(2,2);
    public bool isWalkable;
    public bool isexplored;
    public bool isPath;
    public Nodeclass connectedTo;

    public Nodeclass(Vector2Int Coordinates,bool isWalkable)
    {
        this.Coordinates = Coordinates;
        this.isWalkable = isWalkable;
    }
}
