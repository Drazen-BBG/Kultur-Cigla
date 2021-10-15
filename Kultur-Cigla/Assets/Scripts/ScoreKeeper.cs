using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int correctAnswers = 0;
    private int questionsSeen = 0;


    public int GetCorrectAnsweres()
    {
        return correctAnswers;
    }

    public void SetIncrementCorrectAnswers()
    {
        correctAnswers++;
    }

    public int GetquestionsSeen()
    {
        return questionsSeen;
    }

    public void SetIncrementquestionsSeen()
    {
        questionsSeen++;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(correctAnswers / (float)questionsSeen* 100);
    }

}
