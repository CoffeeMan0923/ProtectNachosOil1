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
    void OnMouseDown()
    {
        if (isplacable == true)
        {
            tissyselect.summonTissy((int)cordinates.x,(int)cordinates.y);  
        }
    }
}
