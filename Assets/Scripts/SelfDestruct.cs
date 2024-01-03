using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float Timebeforedestroyed = 5;
    [SerializeField] GameObject Particle;
    [SerializeField] GameObject ParticlePosition;
    public bool activateParticles;
    void Start()
    {
        if (activateParticles)
        {
            Instantiate(Particle,gameObject.transform.position,ParticlePosition.transform.rotation);
        }
        Invoke("SelfDestroy", Timebeforedestroyed);
    }
    void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
