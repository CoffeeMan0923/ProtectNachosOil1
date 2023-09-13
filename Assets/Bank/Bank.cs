using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI oildisplay;
    [SerializeField] int goldreward = 25;
    [SerializeField] int goldpenalty = 25;
    [SerializeField] int startingBalance = 150;
    [SerializeField]int currentBalance;
    public int CurrenBalance {get {return currentBalance;} }

    // Start is called before the first frame update
    private void Start()
    {
        currentBalance = startingBalance;
        UpdateOil();
    }
    public void Deposit(int amount)
    {
        UpdateOil();
        currentBalance += Mathf.Abs(amount);
    }

    public void Whithdraw(int amount)
    {
        UpdateOil();
        currentBalance -= Mathf.Abs(amount);
    }
    void UpdateOil()
    {
        oildisplay.text = "Oil:" + currentBalance;
    }


    // Update is called once per frame
    void Update()
    {
        UpdateOil();
    }
}
