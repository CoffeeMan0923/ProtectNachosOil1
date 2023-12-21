using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gordomramsy : MonoBehaviour
{
    [SerializeField] GameObject Explosionparticles;
    [SerializeField] GameObject ExplosionLocation;
    [SerializeField] float HellStormSpeed = 2.5f;
    SoundManager soundManager;
    bool hasCollided; 
    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, -HellStormSpeed,0f);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided)
        {
            hasCollided = true;
            Collided();
        }
    }
    void Collided()
    {
        soundManager.cabinExplode();
        Instantiate(Explosionparticles,ExplosionLocation.transform.position,Quaternion.identity);
        Invoke("SelfDestruct",0.7f);
    }
    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
