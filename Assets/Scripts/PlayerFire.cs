using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private PlayerRotator playerRotator;
    private List<int> shotCache = new List<int>();

    private void Start()
    {
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

        if (playerRotator.Rotating) return;

        foreach (var shotDirection in shotCache)
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
            Sounds.PlaySound("pewpew");
            var gun = playerRotator.gunsPosition[shotDirection];
            gun.GetComponent<LaserShooter>().Shot(shotRotation);
        }
        shotCache.Clear();
    }
}