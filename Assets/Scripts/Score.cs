using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Text scoreDisplay;


    public void Add(int i  = 1)
    {
        score += i;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        scoreDisplay.text = $"Score : {score}";
    }

    public void Substract(int i = 1)
    {
        score-=i;
        UpdateScoreDisplay();
    }


}
