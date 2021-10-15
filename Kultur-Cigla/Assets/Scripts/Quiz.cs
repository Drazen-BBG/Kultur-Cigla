using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Quiz : MonoBehaviour
{
    [Header("Questions:")]
    [SerializeField] private TextMeshProUGUI questionText;
    private QuestionsSO currentQuestion;

    [SerializeField] List<QuestionsSO> questions = new List<QuestionsSO>();

    [Header("Answers:")]
    [SerializeField] private GameObject[] answerButtons;
    private int correctAnswerIndex;
    private bool hasAnsweredEarly;

    [Header("Button Colors:")]
    [SerializeField] private Sprite defaultAnswerSprite;
    [SerializeField] private Sprite correcttAnswerSprite;

    [Header("Timer:")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Scoring:")]
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper scorekeeper;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        scorekeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DispalyAnswer(-1);
            SetButtonState(false);
        }
    }

    private void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DispalyAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score : " + scorekeeper.CalculateScore() + "%";

    }

    private void DispalyAnswer(int index)
    {
        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Tačno!";
            answerButtons[index].GetComponent<Image>().sprite = correcttAnswerSprite;

            scorekeeper.SetIncrementCorrectAnswers();
        }
        else
        {
            questionText.text = "Žao mi je, tačan odgovor je: \n" + currentQuestion.GetAnswer(currentQuestion.GetCorrectAnswerIndex());
            answerButtons[currentQuestion.GetCorrectAnswerIndex()].GetComponent<Image>().sprite = correcttAnswerSprite;
        }
    }

    private void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
            scorekeeper.SetIncrementquestionsSeen();
        }
        
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }

    }

    private void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Button>().interactable = state;
        }
    }

    private void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Image>().sprite = defaultAnswerSprite;
        }
    }
}
