using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;

    public void Add()
    {
        score++;
        Debug.Log("score : " + score);
    }

    public void Substract()
    {
        score--;
        Debug.Log("score : " + score);

    }
}
