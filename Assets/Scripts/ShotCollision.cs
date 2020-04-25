using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCollision : MonoBehaviour
{
    public Score score;
    void OnCollisionEnter(Collision collision)
    {
        //Same color
        if (collision.gameObject.CompareTag(this.tag))
        {
            score.Add(); 
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        //different color
        else
        {
            score.Substract();
            Destroy(this.gameObject);
        }
    }
}
