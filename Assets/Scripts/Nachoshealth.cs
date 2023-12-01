using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Nachoshealth : MonoBehaviour
{
    float damage;
    [SerializeField] ParticleSystem cabinExplosionSFX;
    [SerializeField] TextMeshProUGUI HealthDisplay;
    [SerializeField] GameObject Cabin;
    [SerializeField] GameObject Director;
    [SerializeField] float penguinDamage = 1;
    [SerializeField] float batistaDamage = 20;
    [SerializeField] float cabinHealth = 20;
    bool hasExploded = false;
    bool Shake = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Batista")
        {
            damage = batistaDamage;
            CabinShake();
        }
        else if(other.gameObject.tag == "Penguin")
        {
            damage = penguinDamage;
            CabinShake();
        }
        cabinHealth = cabinHealth - damage;
    }

    // Update is called once per frame
    void Update()
    {
        HealthDisplay.text = "Health" + cabinHealth;
        if (cabinHealth <= 0)
        {
            Director.GetComponent<PlayableDirector>().enabled = true;
            Invoke("CabinExplosion", 2);
            Invoke("cabinDown", 2);
            Invoke("Reload", 8f);
            CabinShakeMultiple();
        }
    }
    void CabinExplosion()
    {
        if (!hasExploded)
        {
            hasExploded = true;
            cabinExplosionSFX.Play();
        }
    }
    void CabinShakeMultiple()
    {
        if (Shake)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            Shake = false;
            Invoke("CabinShake", 0.401f);
            Invoke("TrueDelay", 0.401f);
        }
    }
    void TrueDelay()
    {
        Shake = true;
    }
    void CabinShake()
    {
        Cabin.transform.Rotate(0, 0, 3, Space.Self);
        Invoke("cabinright", 0.2f);
        Invoke("cabinright2", 0.4f);
    }
    void cabinright()
    {
        Cabin.transform.Rotate(0, 0, -6, Space.Self);
    }
    void cabinright2()
    {
        Cabin.transform.Rotate(0, 0, 3, Space.Self);
    }
    void cabinDown()
    {
        Cabin.transform.Translate(0, -0.2f, 0); 
    }
    void Reload()
    {
        SceneManager.LoadScene("NachosMenu");
    }
}
