using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip iceBreakSound, gameOverSound, deathSound, landSound;
    public AudioSource soundFx;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void IceBreakSound()
    {
        soundFx.clip = iceBreakSound;
        soundFx.Play();
    }

    public void GameOverSound()
    {
        soundFx.clip = gameOverSound;
        soundFx.Play();
    }

    public void DeathSound()
    {
        soundFx.clip = deathSound;
        soundFx.Play();
    }

    public void LandSound()
    {
        soundFx.clip = landSound;
        soundFx.Play();
    }
}
