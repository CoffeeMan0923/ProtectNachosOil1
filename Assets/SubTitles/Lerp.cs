using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    public bool Lerps;
    Vector3 endposition;
    Vector3 startposition;
    [SerializeField] float lerpduration = 8f;
    float elapsedtime;
    Cam cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Cam>();
        endposition = cam.transform.position;
        startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Lerps)
        {
            elapsedtime += Time.deltaTime;
            float percentagecomplete = elapsedtime / lerpduration;

            transform.position = Vector3.Lerp(startposition, endposition, percentagecomplete);
        }
    }
}
