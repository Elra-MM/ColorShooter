using System.Collections;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    //I would use Serialized fields with private variables rather than public variables as we don't want other class to touch them
    public float Speed;
    public GameObject RedGun;
    public GameObject YellowGun;
    public GameObject BlueGun;
    public GameObject GreenGun;
    public GameObject[] gunsPosition { get; } = new GameObject[4]; //I would use a list or a Enumerable rather than a array (more modularity, linq available)

    public bool Rotating; //I would use a observable to fire when it's rotating or not 

    //Hum..It's literally an enum...
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
        if (!Rotating)
        {
            Rotating = true;
            float angle = clockwise ? 10 : -10;
            for (int i = 0; i < 9; i++)
            {
                //I would prefer something like this : this.transform.RotateAround(this.transform.position, Vector3.forward, angle);
                this.transform.Rotate(new Vector3(0.0f, angle, 0.0f));
                yield return new WaitForSeconds(Speed);
            }
            Rotating = false;
            if (clockwise)
                UpdateGunsPositionClockwise();
            else
                UpdateGunsPositionCounterClockwise();
        }
    }
    
    void Update()
    {
        if (Time.timeScale == 0) return;
        if (Input.GetButtonDown("Rotate"))
        {
            //Prefer : StartCoroutine(nameof(Rotate), Input.GetAxisRaw("Rotate") > 0);
            
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
