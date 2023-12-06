
using UnityEngine;
using TMPro;
[ExecuteAlways]
public class Cordinates : MonoBehaviour
{
    [SerializeField] Color deaultColor= Color.white;
    [SerializeField] Color blokedColor = Color.gray;
    [SerializeField] Color ExploredColor = Color.yellow;
    [SerializeField] Color PathColor = new Color(1f, 0.5f, 0f );
    Vector2Int cordinates = new Vector2Int();
    TextMeshPro label;
    Gridymanager gridymanager;
    [SerializeField] bool ispath;
    void Awake()
    {
        
        gridymanager = FindObjectOfType<Gridymanager>();
        label = GetComponent<TextMeshPro>();
        //DisplayCordinates();
        InvokeRepeating("DisplayCordinates",0, 1);
    }
    void Start()
    {
        label.enabled = false;
    }
    void Update()
    {
        if (!Application.isPlaying && !ispath)
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
        if(gridymanager == null)
        {
            return;
        }
        Nodeclass nodeclass = gridymanager.GetNode(cordinates);
        if (nodeclass == null)
        {
            return;
        }
        if (!nodeclass.isWalkable)
        {
            label.color = blokedColor;
        }
        else if (nodeclass.isPath)
        {
            label.color= PathColor;
        }
        else if (nodeclass.isexplored)
        {
            label.color = ExploredColor;
        }
        else
        {
            label.color=deaultColor;
        }
        
    }

    void DisplayCordinates()
    {
        cordinates.x = Mathf.RoundToInt(transform.parent.position.x / 0.25f);
        cordinates.y = Mathf.RoundToInt(transform.parent.position.z / 0.25f);
        label.text = $"{cordinates.x},{cordinates.y}";
    }

    void updatename()
    {
        transform.parent.name=cordinates.ToString();
    }
}
