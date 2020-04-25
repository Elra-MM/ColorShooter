using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    public int CurrentLives;
    private const string enemyTag = "Enemy";
    
    void Start()
    {
        CurrentLives = 3;
    }
    void OnCollisionEnter(Collision collision)
    {
        CurrentLives--;
        Destroy(collision.gameObject);
    }
}
