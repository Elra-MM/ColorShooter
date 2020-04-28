using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private static AudioClip explosion, pewpew;
    private static AudioSource audioSource;

    private void Awake()
    {
        explosion = Resources.Load<AudioClip>("Sounds/Explosion");
        pewpew = Resources.Load<AudioClip>("Sounds/PewPew");

        audioSource = this.GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "explosion":
                audioSource.PlayOneShot(explosion);
                break;
            case "pewpew":
            default:
                audioSource.PlayOneShot(pewpew);
                break;
        }
    }
}
