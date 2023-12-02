using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlotingText : MonoBehaviour
{
    CanvasLoc canvasLoc;
    public float scaleFactor = 0.5f;
    public TextMeshProUGUI textMesh;
    public float fadeSpeed = 0.5f;

    void Start()
    {
        canvasLoc = FindObjectOfType<CanvasLoc>();
        gameObject.transform.parent = canvasLoc.transform;
    }

    void Update()
    {
        Color currentColor = textMesh.color;
        float newAlpha = Mathf.Clamp01(currentColor.a - fadeSpeed * Time.deltaTime);
        textMesh.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
        if (newAlpha <= 0f)
        {
            gameObject.SetActive(false);
        }
        gameObject.transform.Translate(0, 0.6f, 0);

    }
}
