using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;
    public AudioSource Audios;
    public AudioSource SFX;

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
    }


    private void PlayMusic(AudioClip clip)
    {
        Audios.clip = clip;
        Audios.Play();
    }

    private void PlaySound(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
