using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField] GameObject Wordsfordificulty;
    [SerializeField] GameObject Backround;
    [SerializeField] GameObject Slider;
    [SerializeField] GameObject MyChin;
    [SerializeField] GameObject TheyTookMyChin;
    [SerializeField] public GameObject Nomyoil;
    [SerializeField] public GameObject TheyAreTakingOil;
    [SerializeField] public GameObject Moreoilline;
    [SerializeField] public GameObject Pos;
    [SerializeField] float penguinDamage = 1;
    [SerializeField] float batistaDamage = 2;
    [SerializeField] float ramsyDamage = 3;
    [SerializeField] float cabinHealth = 20;
    int random;
    bool TissyClack;
    SoundManager soundManager;
    bool hasExploded = false;
    bool Shake = true;
    bool insettings;
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
            random = Random.Range(0,4);
            if(random == 0)
            {
                Instantiate(MyChin,Pos.gameObject.transform.position,Quaternion.identity);
            }
            if(random == 3)
            {
                Instantiate(TheyTookMyChin, Pos.gameObject.transform.position, Quaternion.identity);
            }
            soundManager.CabinDamaged(random);
        }
        else if(other.gameObject.tag == "Penguin")
        {
            SmokeSFX.Play();
            damage = penguinDamage;
            CabinShake();
            cabinHealth = cabinHealth - damage;
            random = Random.Range(0, 4);
            soundManager.CabinDamaged(random);
            if(random == 0)
            {
                Instantiate(Nomyoil, Pos.gameObject.transform.position,Quaternion.identity);
            }
            if (random == 1)
            {
                Instantiate(Nomyoil, Pos.gameObject.transform.position, Quaternion.identity);
            }
            if (random == 2)
            {
                Instantiate(Nomyoil, Pos.gameObject.transform.position, Quaternion.identity);
            }
        }
        if(other.gameObject.tag == "Ramsy")
        {
            SmokeSFX.Play();
            damage = ramsyDamage;
            CabinShake();
            cabinHealth = cabinHealth - damage;
            random = Random.Range(0, 4);
            soundManager.CabinDamaged(random);
        }
        
    }
    public void GetIntoSettings()
    {
        Wordsfordificulty.SetActive(true);
        Backround.SetActive(true);
        Slider.SetActive(true);

    }
    public void ExitSettings()
    {
        Wordsfordificulty.SetActive(false);
        Backround.SetActive(false);
        Slider.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        HealthDisplay.text = "" + cabinHealth;
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
