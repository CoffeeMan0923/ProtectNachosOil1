using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] Tissieselect tissieselect;
    [SerializeField] TextMeshProUGUI oildisplay;
    [SerializeField] int oilreward = 25;
    [SerializeField] int oilpenalty = 25;
    [SerializeField] int startingBalance = 150;
    [SerializeField]int currentBalance;
    SoundManager soundManager;
    public int CurrenBalance {get {return currentBalance;} }

    // Start is called before the first frame update
    public GameObject Minus75;
    public GameObject Minus150;
    public GameObject Minus500;
    public GameObject Plus25;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        currentBalance = startingBalance;
        UpdateOil();
    }
    public void Deposit(int amount)
    {
        soundManager.PlayMoneyGetSound();
        Instantiate(Plus25);
        UpdateOil();
        currentBalance += Mathf.Abs(amount);
    }

    public void Whithdraw(int amount)
    {
        if (currentBalance > 0)
        {
            if(amount == 75)
            {
                Instantiate(Minus75);
            }
            else if(amount == 150)
            {
                Instantiate(Minus150);
            }
            if(amount == 500)
            {
                Instantiate(Minus500);
            }
            UpdateOil();
            currentBalance -= Mathf.Abs(amount);
        }
    }
    void UpdateOil()
    {
        oildisplay.text = "Oil:" + currentBalance;
    }


    // Update is called once per frame
    void Update()
    {
        tissieselect.Cash(currentBalance);
        UpdateOil();
        if (currentBalance <= 0)
        {
            currentBalance = 0;
        }
    }
}
