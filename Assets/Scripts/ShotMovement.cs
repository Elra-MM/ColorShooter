using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.up * (Time.deltaTime * 5.0f));
        if (Vector3.Distance(transform.position , new Vector3(0,0,0)) >= 5f)
        {
            Destroy(this.gameObject);
        }
    }
}
