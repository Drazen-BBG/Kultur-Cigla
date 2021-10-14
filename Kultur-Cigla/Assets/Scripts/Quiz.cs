using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuestionsSO question;
    [SerializeField] private GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] private Sprite defaultAnswerSprite;
    [SerializeField] private Sprite correcttAnswerSprite;

    void Start()
    {
        questionText.text = question.GetQuestion();

        

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = question.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Tačno!";
            answerButtons[index].GetComponentInChildren<Image>().sprite = correcttAnswerSprite;
        }
        else
        {
            questionText.text = "Žao mi je, tačan odgovor je: \n" + question.GetAnswer(question.GetCorrectAnswerIndex());
            answerButtons[question.GetCorrectAnswerIndex()].GetComponentInChildren<Image>().sprite = correcttAnswerSprite;
        }
    }
}
