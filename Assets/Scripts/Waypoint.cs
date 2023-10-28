using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] int cost = 75;
    public bool CreateOiler(Oiler tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return false;
        }
        if (bank.CurrenBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Whithdraw(cost);
            return true;
        }

        return false;

    }
    //if error replace prefabs Oilist,Ballonist from serializable to public
    [SerializeField] Oiler[] tissyList;
    Oiler selectedTissy;
    TissieSelect tissyselect;
    public bool isplacable = true;
    int selctedCharacterNum = 0;
    
    public void SelectedCharacter(int CharacterNum)
    {
        int selctedCharacterNum = CharacterNum ;
    }
    void Start()
    {
        selectedTissy = tissyList[selctedCharacterNum];
    }
    void Update()
    {
        selectedTissy = tissyList[selctedCharacterNum];
    }
    

    void OnMouseDown()
    {
        if (isplacable == true)
        {
             bool isPlaced=selectedTissy.CreateOiler(selectedTissy, transform.position);
            isplacable = !isPlaced;
        }
    }
}
