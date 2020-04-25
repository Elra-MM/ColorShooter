using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    public float Speed;
    public GameObject RedGun;
    public GameObject YellowGun;
    public GameObject BlueGun;
    public GameObject GreenGun;
    public GameObject[] gunsPosition { get; } = new GameObject[4];

    public bool Rotating;

    public const int Left = 0;
    public const int Up = 1;
    public const int Right = 2;
    public const int Down = 3;
    
    private void Start()
    {
        gunsPosition[Left] = RedGun;
        gunsPosition[Up] = YellowGun; 
        gunsPosition[Right] = BlueGun; 
        gunsPosition[Down] = GreenGun;
    }

    IEnumerator Rotate(bool clockwise)
    {
        Rotating = true;
        float angle = clockwise ? 10 : -10;
        for (int i= 0; i < 9; i++)
        {
            this.transform.Rotate(new Vector3(0.0f,angle,0.0f));
            yield return new WaitForSeconds(Speed);
        }
        Rotating = false;
        if (clockwise)
            UpdateGunsPositionClockwise();
        else
            UpdateGunsPositionCounterClockwise();
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Rotate"))
        {
            //Turn clockwise
            if (Input.GetAxisRaw("Rotate") > 0)
            {
                StartCoroutine(nameof(Rotate), true);
                
                
            }
            //Turn CounterClockwise
            else
            {
                StartCoroutine(nameof(Rotate), false);           
            }
        }
    }
    void UpdateGunsPositionClockwise()
    {
        var left = gunsPosition[Left];
        gunsPosition[Left] = gunsPosition[Down];
        gunsPosition[Down] = gunsPosition[Right];
        gunsPosition[Right] = gunsPosition[Up];
        gunsPosition[Up] = left;
    }
    void UpdateGunsPositionCounterClockwise()
    {
        var left = gunsPosition[Left];
        gunsPosition[Left] = gunsPosition[Up];
        gunsPosition[Up] = gunsPosition[Right];
        gunsPosition[Right] = gunsPosition[Down];
        gunsPosition[Down] = left;
    }
    
    
}
