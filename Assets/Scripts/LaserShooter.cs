using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    public GameObject shotPrefab;
    private GameObject GameLogic;
    private Score score;

    private void Start()
    {
        GameLogic = GameObject.Find("GameLogic"); 
        score = GameLogic.GetComponent<Score>();
    }

    public void Shot(Vector3 direction, Vector3 rotation)
    {
        var shot = Instantiate(shotPrefab, transform.position, Quaternion.Euler(rotation));
        shot.GetComponent<ShotCollision>().score = score;
    }
}
