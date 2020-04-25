using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    public GameObject shotPrefab;

    public void Shot(Vector3 direction, Vector3 rotation)
    {
        var shot = Instantiate(shotPrefab, transform.position, Quaternion.Euler(rotation));
        var shotMovement = shot.GetComponent<ShotMovement>();
        shotMovement.direction = Vector3.up;
        shotMovement.enabled = true;
    }
}
