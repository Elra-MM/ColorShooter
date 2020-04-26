using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, Vector3.zero, Speed * Time.deltaTime);
    }

    public void IncreaseSpeed()
    {
        Speed += 0.5f;
    }
}
