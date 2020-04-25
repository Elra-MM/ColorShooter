using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private PlayerRotator playerRotator;
    private void Start()
    {
        playerRotator = this.GetComponent<PlayerRotator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            //RIGHT
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                var gun = playerRotator.gunsPosition[PlayerRotator.Right];
                gun.GetComponent<LaserShooter>().Shot(Vector3.right, new Vector3(90,0,-90));
            }
            //LEFT
            else
            {
                var gun = playerRotator.gunsPosition[PlayerRotator.Left];
                gun.GetComponent<LaserShooter>().Shot(Vector3.left, new Vector3(90,0,90));
            }
        }
        if (Input.GetButtonDown("Vertical"))
        {
            //UP
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                var gun = playerRotator.gunsPosition[PlayerRotator.Up];
                gun.GetComponent<LaserShooter>().Shot(Vector3.forward, new Vector3(90,0,0));
            }
            //DOWN
            else
            {
                var gun = playerRotator.gunsPosition[PlayerRotator.Down];
                gun.GetComponent<LaserShooter>().Shot(Vector3.back, new Vector3(90,0,180)); 
            }
        }
        
    }
}
