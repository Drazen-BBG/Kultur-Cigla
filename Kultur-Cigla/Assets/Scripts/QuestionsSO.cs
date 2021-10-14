using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName ="Question")]
public class QuestionsSO : ScriptableObject
{
    //Question
    [TextArea(2,6)]
    [SerializeField] 
    string question = "Enter new question text here";

    //Answers
    [SerializeField]
    string[] answers = new string[4];
    [SerializeField]
    int correctAnswerIndex;


    //Question categories 
    [SerializeField]
    bool sport, history, geography, music, science;
    


    //Getter Methods 
    public string GetQuestion()
    {
        return question;
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

    public string GetCorrectAnswer(int index)
    {
        return answers[index];
    }
}
