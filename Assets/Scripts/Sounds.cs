using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] AudioClip[] sounds;
    [SerializeField] bool instant;
    [SerializeField] float seconds;
    AudioSource source;
    GameObject Sametissy;
    // Start is called before the first frame update
    void Start()
    {

        source = GetComponent<AudioSource>();
        if (instant)
        {
            CrackKnuckles();
        }
        else if(!instant)
        {
            Invoke("CrackKnuckles", seconds);
        }
        source.clip = sounds[Random.Range(0, sounds.Length)]; ; 
        

    }
    void CrackKnuckles()
    {
        if (source != null)
        {
            source.Play();
        }
        else if (source == null)
        {
            Sametissy.AddComponent<AudioSource>();
            Debug.Log("Object needs AudioSourse");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
