using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;
    public AudioSource Audios;
    public AudioSource SFX;
    public AudioSource OTHERSFX;
    public AudioClip[] Kicks;
    public AudioClip gameMusic;
    int random;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        if (Audios.clip != gameMusic && SceneManager.GetActiveScene().name == "SampleScene")
        {
            Audios.clip = gameMusic;
        }
    }


    public void PlayMusic(AudioClip clip)
    {
        Audios.clip = clip;
        Audios.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
    public void PlayOtherSFX(AudioClip clip)
    {
        OTHERSFX.PlayOneShot(clip);
    }
    public void BasicPunchSFX()
    {
        random = Random.Range(0, Kicks.Length);
        SFX.PlayOneShot(Kicks[random]);
    }
}
