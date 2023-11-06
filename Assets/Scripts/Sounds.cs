using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] AudioClip[] sounds;
    [SerializeField] int sounddelay;
    AudioSource source;
    GameObject Sametissy;
    // Start is called before the first frame update
    void Start()
    {
        Sametissy.GetComponent<AudioSource>();

        source = GetComponent<AudioSource>();
        source.clip = sounds[Random.Range(0, sounds.Length)];
        if (sounddelay <= 0)
        {
            CrackKnuckles();
        }
        else if(sounddelay > 0)
        {
            Invoke("Playsound", sounddelay);
        }
        void CrackKnuckles()
        {
            if(Sametissy != null)
            {
                source.Play();
            }
            else if (Sametissy == null)
            {
                CrackKnuckles();
                Sametissy.AddComponent<AudioSource>();
                Debug.Log("Object needs AudioSourse");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
