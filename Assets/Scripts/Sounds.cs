using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private static AudioClip explosion, pewpew, wrongColor, backgroundMusic;
    private static AudioSource audioSource;

    private void Awake()
    {
        explosion = Resources.Load<AudioClip>("Sounds/Explosion");
        pewpew = Resources.Load<AudioClip>("Sounds/PewPew");
        wrongColor = Resources.Load<AudioClip>("Sounds/Hurt");
        backgroundMusic = Resources.Load<AudioClip>("Sounds/Music");
        

        audioSource = this.GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "music":
                audioSource.PlayOneShot(backgroundMusic);
                audioSource.loop = true;
                break;
            case "explosion":
                audioSource.PlayOneShot(explosion);
                audioSource.volume = 0.2f;
                break;
            case "wrongColor":
                audioSource.PlayOneShot(wrongColor);
                audioSource.volume = 0.5f;
                break;
            case "pewpew":
            default:
                audioSource.PlayOneShot(pewpew);
                audioSource.volume = 0.5f;
                break;
        }
    }
}
