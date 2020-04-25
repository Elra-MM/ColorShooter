using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
{
    public Vector3 direction;
    void Update()
    {
        Vector3.MoveTowards(this.transform.position, direction, 2.0f);
    }
}
