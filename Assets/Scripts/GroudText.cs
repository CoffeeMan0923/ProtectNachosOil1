using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GroudText : MonoBehaviour
{
    //public float scaleFactor = 0.5f;
    public TextMeshPro textMesh;
    public float fadeSpeed = 0.5f;
    public bool moves = true;
    [SerializeField] float timebeforefadesout;
    [SerializeField] bool fadeinfirst;
    [SerializeField] bool StartFadingIn;
    [SerializeField] float MoveSpeed = 0.6f;
    bool something;
    bool something2;

    public void FlashG()
    {
        something2 = false;
        fadeinfirst = true;
        StartFadingIn = true;
    }

    void Update()
    {
        if (fadeinfirst == true && StartFadingIn)
        {
            Color currentColor2 = textMesh.color;
            float newAlpha2 = Mathf.Clamp01(currentColor2.a + fadeSpeed * Time.deltaTime);
            textMesh.color = new Color(currentColor2.r, currentColor2.g, currentColor2.b, newAlpha2);
            something = true;
            Invoke("startDisapearing", timebeforefadesout);
        }

        if (fadeinfirst == false && something == false)
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
        if (moves == true)
        {
            gameObject.transform.Translate(0, MoveSpeed, 0);
        }

    }
    void startDisapearing()
    {
        something2 = true;
        fadeinfirst = false;
        StartFadingIn = false;
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
