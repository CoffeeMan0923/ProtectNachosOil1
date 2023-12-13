using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlotingText : MonoBehaviour
{
    CanvasLoc canvasLoc;
    //public float scaleFactor = 0.5f;
    public TextMeshProUGUI textMesh;
    public float fadeSpeed = 0.5f;
    public bool moves = true;
    [SerializeField] float timebeforefadesout;
    [SerializeField] bool fadeinfirst;
    bool something;
    bool something2;

    void Start()
    {
        canvasLoc = FindObjectOfType<CanvasLoc>();
        gameObject.transform.parent = canvasLoc.transform;
    }
    public void Flash()
    {
        something2 = false;
        fadeinfirst = true;
    }

    void Update()
    {
        if (fadeinfirst == true)
        {
            Color currentColor2 = textMesh.color;
            float newAlpha2 = Mathf.Clamp01(currentColor2.a + fadeSpeed * Time.deltaTime);
            textMesh.color = new Color(currentColor2.r, currentColor2.g, currentColor2.b, newAlpha2);
            something = true;
            Invoke("startDisapearing",timebeforefadesout);
        }

        if(fadeinfirst == false && something == false)
        {
            Color currentColor = textMesh.color;
            float newAlpha = Mathf.Clamp01(currentColor.a - fadeSpeed * Time.deltaTime);
            textMesh.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
            if (newAlpha <= 0f)
            {
                gameObject.SetActive(false);
            }
        }
        if (something2)
        {
            startDisapearing();
        }
        if(moves == true)
        {
            gameObject.transform.Translate(0, 0.6f, 0);
        }

    }
    void startDisapearing()
    {
        something2 = true;
        fadeinfirst = false;
        Color currentColor = textMesh.color;
        float newAlpha = Mathf.Clamp01(currentColor.a - fadeSpeed * Time.deltaTime);
        textMesh.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
        //Invoke("stopdisapearing", 2);

    }
    void stopdisapearing()
    {
        something2 = false;
    }
}
