using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //if error replace prefabs Oilist,Ballonist from serializable to public
    Vector2 cordinates = new Vector2Int();
    Tissieselect tissyselect;
    public bool isplacable = true;
    public bool isplacable2 = true;
    public Oiler Oilboy;
    public Oiler Ballonist;
    Waypoint waypoint;
    bool isballonist;
    bool isoiler;
    bool isPlaced = true;
    bool isPlaced2 = true;

    void Start()
    {
        tissyselect = FindObjectOfType<Tissieselect>();
    }
    void Update()
    {

    }
    public void isPlacable(bool isPlaced)
    {
        isplacable = !isPlaced;
    }
    
    void Cordinates()
    {
        cordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        cordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
    }
    public void summonTissy()
    {
        if (isoiler)
        {
            isPlaced = Ballonist.CreateOiler(Ballonist, gameObject.transform.position);
            waypoint.isPlacable(isPlaced);
        }
        if (isballonist)
        {
            isPlaced2 = Oilboy.CreateOiler(Oilboy,gameObject.transform.position);
            waypoint.isPlacable(isPlaced);
        }
    }
    void OnMouseDown()
    {
        if (isplacable == true)
        {
            summonTissy();  
        }
    }
}
