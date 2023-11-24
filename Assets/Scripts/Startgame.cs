using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startgame : MonoBehaviour
{
    [SerializeField] string Levelname;
    [SerializeField] float TimeBeforeStart = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        Invoke("Loadlevel", TimeBeforeStart);
    }
    void Loadlevel()
    {
        SceneManager.LoadScene(Levelname);
    }
}
