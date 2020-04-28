using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private PlayerRotator playerRotator;
    private Rigidbody rigidBod;
    private void Start()
    {
        playerRotator = this.GetComponent<PlayerRotator>();
    }

    void Update()
    {
        // don't allow firing while rotating
        if (playerRotator.Rotating || Time.timeScale == 0)
        {
            return;
        }
        if (Input.GetButtonDown("Horizontal"))
        {
            //RIGHT
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                var gun = playerRotator.gunsPosition[PlayerRotator.Right];
                gun.GetComponent<LaserShooter>().Shot(new Vector3(90,0,-90));
            }
            //LEFT
            else
            {
                var gun = playerRotator.gunsPosition[PlayerRotator.Left];
                gun.GetComponent<LaserShooter>().Shot(new Vector3(90,0,90));
            }
        }
        if (Input.GetButtonDown("Vertical"))
        {
            //UP
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                var gun = playerRotator.gunsPosition[PlayerRotator.Up];
                gun.GetComponent<LaserShooter>().Shot(new Vector3(90,0,0));
            }
            //DOWN
            else
            {
                var gun = playerRotator.gunsPosition[PlayerRotator.Down];
                gun.GetComponent<LaserShooter>().Shot(new Vector3(90,0,180)); 
            }
        }
        
    }
}
