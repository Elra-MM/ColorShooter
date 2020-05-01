using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCollision : MonoBehaviour
{
    public Score score;
    public GameObject explosionPrefab; 
    
    void OnCollisionEnter(Collision collision)
    {
        //Same color
        if (collision.gameObject.CompareTag(this.tag))
        {
            Sounds.PlaySound("explosion");
            score.Add(); 
            Destroy(this.gameObject);
            var explosion = Instantiate(explosionPrefab, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(explosion, 3);
            Destroy(collision.gameObject);
        }
        //different color
        else
        {
            Sounds.PlaySound("wrongColor");
            score.Substract();
            Destroy(this.gameObject);
        }
    }
}
