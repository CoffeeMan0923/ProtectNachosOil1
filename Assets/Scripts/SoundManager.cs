using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] ballonistSpawnSounds;
    [SerializeField] private AudioClip[] penguinDamageSounds;
    [SerializeField] private AudioClip[] batistaDamageSounds;
    [SerializeField] private AudioClip[] oilboySpawnSounds;
    [SerializeField] private AudioClip penguinSpawnSound;
    [SerializeField] private AudioClip batistaSpawnSound;
    [SerializeField] private AudioClip moneySpendSound;
    public static SoundManager Instance;
    AudioSource source;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        source = GetComponent<AudioSource>();
    } 
    public void PlayPenguinsound()
    {
        source.clip = penguinDamageSounds[Random.Range(0, penguinDamageSounds.Length)];
        source.Play();
    }
    public void PlayBatistasound()
    {
        source.clip = batistaDamageSounds[Random.Range(0, batistaDamageSounds.Length)];
        source.Play();
    }
    public void OilboySpawn()
    {
        source.clip = oilboySpawnSounds[Random.Range(0, oilboySpawnSounds.Length)];
        source.Play();
    }
    public void BallonistSpawn()
    {
        source.clip = ballonistSpawnSounds[Random.Range(0, ballonistSpawnSounds.Length)];
        source.Play();
    }
    public void BatistaSpawn()
    {
        source.clip = batistaSpawnSound;
        source.Play();
    }
    public void PenguinSpawn()
    {
        source.clip = penguinSpawnSound;
        source.Play();
    }
}
