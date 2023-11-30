using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nachoshealth : MonoBehaviour
{
    float damage;
    [SerializeField] TextMeshProUGUI HealthDisplay;
    [SerializeField] GameObject Cabin;
    [SerializeField] float penguinDamage = 1;
    [SerializeField] float batistaDamage = 20;
    [SerializeField] float cabinHealth = 20;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Batista")
        {
            damage = batistaDamage;
        }
        else if(other.gameObject.tag == "Penguin")
        {
            damage = penguinDamage;
        }
        Cabin.transform.Rotate(0, 0, 3, Space.Self);
        cabinHealth = cabinHealth - damage;
    }

    // Update is called once per frame
    void Update()
    {
        HealthDisplay.text = "Health" + cabinHealth;
        if (cabinHealth <= 0)
        {
            Invoke("Reload", 1f);
        }
    }
    void Reload()
    {
        SceneManager.LoadScene("NachosMenu");
    }
}
