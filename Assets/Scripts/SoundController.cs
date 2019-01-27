using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum FX
{
    Take, Drop, CantDrop, Toy, GameOver, Victory, BeginLevel, Click
}

public class SoundController : MonoBehaviour
{
    public static SoundController instance = null;

    public AudioClip music;

    public AudioClip takeSound;
    public AudioClip dropSound;
    public AudioClip cantDropSound;
    public AudioClip toySound;
    public AudioClip gameOverSound;
    public AudioClip victorySound;
    public AudioClip beginLevelSound;

    public AudioClip clickSound;

    private AudioSource fxSource;
    private AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(instance);

        musicSource = GetComponent<AudioSource>();
        fxSource = transform.GetChild(0).GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (!musicSource.isPlaying)
        {
            PlayMusic();
        }
    }

    private void PlayMusic()
    {
        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayFX(FX fx)
    {
        fxSource.Stop();
        fxSource.clip = null;
        fxSource.loop = false;
        
        switch (fx)
        {
            case FX.BeginLevel:
                fxSource.clip = beginLevelSound;
                break;
            case FX.CantDrop:
                fxSource.clip = cantDropSound;
                break;
            case FX.Click:
                fxSource.clip = clickSound;
                break;
            case FX.Drop:
                fxSource.clip = dropSound;
                break;
            case FX.GameOver:
                fxSource.clip = gameOverSound;
                break;
            case FX.Take:
                fxSource.clip = takeSound;
                break;
            case FX.Toy:
                fxSource.clip = toySound;
                break;
            case FX.Victory:
                fxSource.clip = victorySound;
                break;
        }

        fxSource.Play();
    }
}
