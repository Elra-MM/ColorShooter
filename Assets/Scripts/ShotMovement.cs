using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
{
    public Vector3 direction;
    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
        if (Vector3.Distance(transform.position , new Vector3(1,1,1)) >= 8.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
