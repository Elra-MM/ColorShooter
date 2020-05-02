using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private static AudioSource audioSourceMusic;
    private static AudioSource audioSourceFSX;
    private static AudioClip explosion, pewpew, wrongColor, backgroundMusic;
    private static float musicVolume = 0.5f;
    private static float sfxVolume = 0.5f;

    private void Awake()
    {
        explosion = Resources.Load<AudioClip>("Sounds/Explosion");
        pewpew = Resources.Load<AudioClip>("Sounds/PewPew");
        wrongColor = Resources.Load<AudioClip>("Sounds/Hurt");
        backgroundMusic = Resources.Load<AudioClip>("Sounds/Music");

        audioSourceFSX = this.GetComponents<AudioSource>()[0];
        audioSourceMusic = this.GetComponents<AudioSource>()[1];
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "music":
                audioSourceMusic.PlayOneShot(backgroundMusic);
                audioSourceMusic.loop = true;
                audioSourceMusic.volume = musicVolume;
                break;
            case "explosion":
                audioSourceFSX.PlayOneShot(explosion);
                audioSourceFSX.volume = sfxVolume;
                break;
            case "wrongColor":
                audioSourceFSX.PlayOneShot(wrongColor);
                audioSourceFSX.volume = sfxVolume;
                break;
            case "pewpew":
            default:
                audioSourceFSX.PlayOneShot(pewpew);
                audioSourceFSX.volume = sfxVolume;
                break;
        }
    }

    public void SetMusicVolume(float volume)
    {
        audioSourceMusic.Stop();
        musicVolume = volume;
        PlaySound("music");
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        PlaySound("explosion");
    }
}
