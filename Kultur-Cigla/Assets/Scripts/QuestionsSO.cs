using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName ="Question")]
public class QuestionsSO : ScriptableObject
{
    //Question
    [TextArea(2,5)] [SerializeField] private string question = "Enter new question text here";

    //Answers
    [SerializeField] private string[] answers = new string[4];
    [SerializeField] private int correctAnswerIndex;


    //Question categories 
    [SerializeField] private bool general, sport, history, geography, music, science;
    


    //Getter Methods 
    public string GetQuestion()
    {
        return question;
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }
}
