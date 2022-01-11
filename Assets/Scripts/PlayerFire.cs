using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerRotator))]
public class PlayerFire : MonoBehaviour
{
    private PlayerRotator playerRotator;
    private List<int> shotCache = new List<int>(); //doesn't seem to be usefull..why not shot directly rather than add to a list

    private void Start()
    {
        //nice but should do something if we don't get the PlayerRotator
        playerRotator = this.GetComponent<PlayerRotator>();
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            //RIGHT
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                shotCache.Add(PlayerRotator.Right);
            }
            //LEFT
            else
            {
                shotCache.Add(PlayerRotator.Left);
            }
        }
        if (Input.GetButtonDown("Vertical"))
        {
            //UP
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                shotCache.Add(PlayerRotator.Up);
            }
            //DOWN
            else
            {
                shotCache.Add(PlayerRotator.Down);
            }
        }

        if (playerRotator.Rotating) return; //should use a subscription to the observable but still,

        foreach (var shotDirection in shotCache) //outch "var", don't use that here
        {
            Vector3 shotRotation;
            switch (shotDirection)
            {
                case PlayerRotator.Right:
                    shotRotation = new Vector3(90, 0, -90);
                    break;
                case PlayerRotator.Left:
                    shotRotation = new Vector3(90, 0, 90);
                    break;
                case PlayerRotator.Up:
                    shotRotation = new Vector3(90, 0, 0);
                    break;
                case PlayerRotator.Down:
                default:
                    shotRotation = new Vector3(90, 0, 180);
                    break;
            }
            Sounds.PlaySound("pewpew"); //nice name but should be a serialized field in case the name changes
            var gun = playerRotator.gunsPosition[shotDirection]; //no need to create a variable here
            gun.GetComponent<LaserShooter>().Shot(shotRotation);
        }
        shotCache.Clear();
    }
}