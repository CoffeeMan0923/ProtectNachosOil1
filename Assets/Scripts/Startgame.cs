using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startgame : MonoBehaviour
{
    [SerializeField] string Levelname;
    [SerializeField] float TimeBeforeStart = 2.5f;
    SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
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
        soundManager.RickSound();
        SceneManager.LoadScene(Levelname);
    }
}
