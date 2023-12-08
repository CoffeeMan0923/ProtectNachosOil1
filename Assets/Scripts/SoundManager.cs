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
    [SerializeField] private AudioClip[] oilboyAttackSounds;
    [SerializeField] private AudioClip[] ballonistAttackSounds;
    [SerializeField] private AudioClip[] cabinDamaged;
    [SerializeField] private AudioClip[] songs;
    [SerializeField] private AudioClip[] CharacterSelectSound;
    [SerializeField] private AudioClip[] moneyGetSound;
    [SerializeField] private AudioClip[] TruckKnucklesSpawnSounds;
    [SerializeField] private AudioClip[] PakageSound;
    [SerializeField] private AudioClip TruckCall;
    [SerializeField] private AudioClip penguinSpawnSound;
    [SerializeField] private AudioClip CabinExplode;
    [SerializeField] private AudioClip CabinTissysDestroyed;
    [SerializeField] private AudioClip batistaSpawnSound;
    [SerializeField] private AudioClip batistacabinSound;
    [SerializeField] private AudioClip penguincabinSound;
    [SerializeField] private AudioClip bloodImpactSound;
    [SerializeField] private AudioClip moneySpendSound;
    [SerializeField] private AudioClip Rickroll;
    private int currentSongIndex = 0;
    private AudioClip Sound;
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
    void Update()
    {
        if (!source.isPlaying)
        {
            // Play the next song
            PlayNextSong();
        }
    }
    public void PlayPenguinsound()
    {
        Sound = penguinDamageSounds[Random.Range(0, penguinDamageSounds.Length)];
        source.PlayOneShot(Sound);
    }
    public void PlayBatistasound()
    {
        Sound = batistaDamageSounds[Random.Range(0, batistaDamageSounds.Length)];
        source.PlayOneShot(Sound);
    }
    public void OilboySpawn()
    {
            Sound = oilboySpawnSounds[Random.Range(0, oilboySpawnSounds.Length)];
        source.PlayOneShot(Sound);
    }
    public void BallonistSpawn()
    {
        Sound = ballonistSpawnSounds[Random.Range(0, ballonistSpawnSounds.Length)];
        source.PlayOneShot(Sound);
    }
    public void BatistaSpawn()
    {
        source.PlayOneShot(batistaSpawnSound);
    }
    public void PenguinSpawn()
    {
        source.PlayOneShot(penguinSpawnSound);
    }
    public void PlayMoneySpendSound()
    {
        source.PlayOneShot(moneySpendSound);
    }
    public void PlayMoneyGetSound()
    {
        Sound = moneyGetSound[Random.Range(0, moneyGetSound .Length)];
        source.PlayOneShot(Sound);
    }
    public void CabinDamaged()
    {
        Sound = cabinDamaged[Random.Range(0, cabinDamaged.Length)];
        source.PlayOneShot(Sound);
    }
    public void PlayCharacterButtonPresedSound()
    {
        Sound = CharacterSelectSound[Random.Range(0, CharacterSelectSound.Length)];
        source.PlayOneShot(Sound);
    }
    public void PenguinCabinEnter()
    {
        source.PlayOneShot(penguincabinSound);
    }
    public void BatistaCabinEnter()
    {
        source.PlayOneShot(batistacabinSound);
    }
    public void ImpactSound()
    {
        source.PlayOneShot(bloodImpactSound);
    }
    public void RickSound()
    {
        float increasedVolume = 2.0f;
        float originalVolume = source.volume;
        source.volume = originalVolume * increasedVolume;
        source.PlayOneShot(Rickroll);
        source.volume = originalVolume;
    }
    public void OilboyAttack()
    {
        Sound = oilboyAttackSounds[Random.Range(0, oilboyAttackSounds.Length)];
        source.PlayOneShot(Sound);
    }
    public void BallonistAttack()
    {
        Sound = ballonistAttackSounds[Random.Range(0, ballonistAttackSounds.Length)];
        source.PlayOneShot(Sound);
    }
    public void cabinExplode()
    {
        source.PlayOneShot(CabinExplode);
    }
    public void cabinTissy()
    {
        source.PlayOneShot(CabinTissysDestroyed);
    }
    void PlayNextSong()
    {

        if (currentSongIndex < songs.Length)
        {
            source.clip = songs[currentSongIndex];
            currentSongIndex++;
            source.Play();

        }
        else
        {
            currentSongIndex = 0;
        }
    }
    public void CallTruckKnuckles()
    {
        source.PlayOneShot(TruckCall);
    }
    public void PlayPakageSound()
    {
        Sound = PakageSound[Random.Range(0, PakageSound.Length)];
        source.PlayOneShot(Sound);
    }
    public void TruckKnucklesSpawnLine()
    {
        Sound = TruckKnucklesSpawnSounds[Random.Range(0, TruckKnucklesSpawnSounds.Length)];
        source.PlayOneShot(Sound);
    }

}

