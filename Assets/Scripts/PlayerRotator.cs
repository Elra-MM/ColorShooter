using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    public float speed = 0.001f;
    IEnumerator TurnClockwise(bool clockwise)
    {
        float angle = clockwise ? 10 : -10;
        for (int i= 0; i < 9; i++)
        {
            this.transform.Rotate(new Vector3(0.0f,angle,0.0f));
            yield return new WaitForSeconds(speed);
        }
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Rotate"))
        {
            if (Input.GetAxisRaw("Rotate") > 0)
            {
                StartCoroutine("TurnClockwise", true);
            }
            else
            {
                StartCoroutine("TurnClockwise", false);           
            }
        }
    }
}
