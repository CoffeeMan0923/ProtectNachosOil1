using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
[ExecuteAlways]
public class Cordinates : MonoBehaviour
{
    [SerializeField] Color deaultColor= Color.white;
    [SerializeField] Color Color = Color.gray;
    Vector2Int cordinates = new Vector2Int();
    TextMeshPro label;
    Waypoint waypoint;
    void Awake()
    {
        waypoint = GetComponentInParent<Waypoint>();
        label = GetComponent<TextMeshPro>();
        DisplayCordinates();
        InvokeRepeating("DisplayCordinates",0, 1);
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            updatename();
            DisplayCordinates();
            
        }
        Colorcordinates();
        Togglelabel();
    }
    void Togglelabel()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }
    void Colorcordinates()
    {
        if(waypoint.Placed == false)
        {
            label.color = deaultColor;
        }
        else
        {
            label.color = Color;
        }
    }

    void DisplayCordinates()
    {
        cordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        cordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = $"{cordinates.x},{cordinates.y}";
    }

    void updatename()
    {
        transform.parent.name=cordinates.ToString();
    }
}
