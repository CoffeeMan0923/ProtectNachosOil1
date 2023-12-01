using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Transform parentObject;
    [SerializeField] private Canvas canvas;
    [SerializeField] private int numberToShow = 42;

    public float moveSpeed = 1f;
    public float fadeSpeed = 1f;

    private void Start()
    {
        CreateFloatingText();
    }

    private void CreateFloatingText()
    {
        // Instantiate TextMeshPro object
        GameObject textObject = new GameObject("FloatingText");
        TextMeshProUGUI textMesh = textObject.AddComponent<TextMeshProUGUI>();

        // Set the parent and canvas
        textObject.transform.SetParent(parentObject);

        // Set the text based on the number
        textMesh.text = numberToShow.ToString();

        // Set initial position
        textObject.transform.position = Camera.main.WorldToScreenPoint(transform.position);

        // Start the animation coroutine
        StartCoroutine(AnimateFloatingText(textObject));
    }

    private IEnumerator AnimateFloatingText(GameObject textObject)
    {
        TextMeshProUGUI textMesh = textObject.GetComponent<TextMeshProUGUI>();

        // Move up and fade out
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            textObject.transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            Color textColor = textMesh.color;
            textColor.a = Mathf.Lerp(1f, 0f, elapsedTime);
            textMesh.color = textColor;

            elapsedTime += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        // Destroy the text object when animation is complete
        Destroy(textObject);
    }
}
