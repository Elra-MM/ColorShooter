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
                gun.GetComponent<LaserShooter>().Shot(Vector3.right);
            }
            //LEFT
            else
            {
                
            }
        }
        if (Input.GetButtonDown("Vertical"))
        {
            //UP
            if (Input.GetAxisRaw("Vertical") > 0)
            {

            }
            //DOWN
            else
            {
                
            }
        }
        
    }
}
