using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Text scoreDisplay;
    public UnityEvent ScoreHasIncreased { get; } = new UnityEvent();
    private int scoreMaximum = 0;
    private const int scoreStepForDifficultyIncrease = 10;
    private EnemiesGenerator enemiesGenerator;


    private void Start()
    {
        this.enemiesGenerator = this.GetComponent<EnemiesGenerator>();
    }
    public void Add(int i  = 1)
    {
        score += i;
        if (score > scoreMaximum)
        {
            scoreMaximum = score;
            if (score % scoreStepForDifficultyIncrease == 0)
            {
                ScoreHasIncreased.Invoke();
            }
        }

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
