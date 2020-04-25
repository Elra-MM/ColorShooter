using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    public int CurrentLives;
    private const string enemyTag = "Enemy";
    // Start is called before the first frame update
    void Start()
    {
        CurrentLives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            CurrentLives--;
            Destroy(collision.gameObject);
        }
    }
}
