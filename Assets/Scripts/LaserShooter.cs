using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    public GameObject shotPrefab;

    public void Shot(Vector3 direction)
    {
        var shot = Instantiate(shotPrefab);
        shot.GetComponent<ShotMovement>().direction = direction;
    }
}
