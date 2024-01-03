using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Gordomramsy : MonoBehaviour
{
    [SerializeField] GameObject Explosionparticles;
    [SerializeField] GameObject ExplosionLocation;
    [SerializeField][Range(0, 7)] public float speed = 1f;
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float HellStormSpeed = 2.5f;
    SoundManager soundManager;
    bool hasCollided;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        StartCoroutine(falltoplace());
    }
    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.Translate(0, -HellStormSpeed, 0f);
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
        Invoke("ExploParticles", 0.2f);
        Invoke("SelfDestruct", 0.7f);
    }
    void ExploParticles()
    {
        soundManager.cabinExplode();
        Instantiate(Explosionparticles, ExplosionLocation.transform.position, Quaternion.identity);
    }
    void SelfDestruct()
    {
        Destroy(gameObject);
    }
    IEnumerator falltoplace()
    {
        
            foreach (Waypoint waypoint in path)
            {
                Debug.Log(gameObject.name + " pos: " + waypoint.gameObject.name);
                Vector3 startposition = transform.position;
                Vector3 endposition = waypoint.transform.position;
                float movepercent = 0f;
                while (movepercent < 1f)
                {
                    movepercent += Time.deltaTime * speed;
                    transform.position = Vector3.Lerp(startposition, endposition, movepercent);
                    yield return new WaitForEndOfFrame();
                }


            }
        
    }
}
