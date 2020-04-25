using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
        if (Vector3.Distance(transform.position , new Vector3(1,1,1)) >= 8.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
