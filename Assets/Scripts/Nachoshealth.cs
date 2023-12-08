using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Nachoshealth : MonoBehaviour
{
    float damage;
    [SerializeField] ParticleSystem SmokeSFX;
    [SerializeField] GameObject RestartButton;
    [SerializeField] ParticleSystem cabinExplosionSFX;
    [SerializeField] TextMeshProUGUI HealthDisplay;
    [SerializeField] GameObject YouLost;
    [SerializeField] GameObject Cabin;
    [SerializeField] GameObject Director;
    [SerializeField] float penguinDamage = 1;
    [SerializeField] float batistaDamage = 20;
    [SerializeField] float cabinHealth = 20;
    bool TissyClack;
    SoundManager soundManager;
    bool hasExploded = false;
    bool Shake = true;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Batista")
        {
            SmokeSFX.Play();
            damage = batistaDamage;
            CabinShake();
            cabinHealth = cabinHealth - damage;
        }
        else if(other.gameObject.tag == "Penguin")
        {
            SmokeSFX.Play();
            damage = penguinDamage;
            CabinShake();
            cabinHealth = cabinHealth - damage;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthDisplay.text = "Health" + cabinHealth;
        if (cabinHealth <= 0)
        {
            Director.GetComponent<PlayableDirector>().enabled = true;
            Invoke("CabinExplosion", 2.5f);
            Invoke("cabinDown", 1);
            Invoke("BackToMenuButton", 10f);
            Invoke("Loser", 8f);
            Invoke("CabinTissys", 0f);
            CabinShakeMultiple();
        }
    }
    void CabinExplosion()
    {
        if (!hasExploded)
        {
            hasExploded = true;
            cabinExplosionSFX.Play();
            soundManager.cabinExplode();
        }
    }
    void CabinTissys()
    {
        if (!TissyClack)
        {
            TissyClack = true;
            soundManager.cabinTissy();

        }
    }
    void BackToMenuButton()
    {
        RestartButton.SetActive(true);
    }
    void Loser()
    {
        YouLost.gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
    }
    void CabinShakeMultiple()
    {
        if (Shake)
        {
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
        Cabin.transform.Rotate(0, 0, 7, Space.Self);
        Invoke("cabinright", 0.2f);
        Invoke("cabinright2", 0.3f);
    }
    void cabinright()
    {
        Cabin.transform.Rotate(0, 0, -14, Space.Self);
    }
    void cabinright2()
    {
        Cabin.transform.Rotate(0, 0, 7, Space.Self);
    }
    void cabinDown()
    {
        Cabin.transform.Translate(0, -0.3f, 0); 
    }
    public void Reload()
    {
        SceneManager.LoadScene("NachosMenu");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
