using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScript endScript;

    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        endScript = FindObjectOfType<EndScript>();
    }
    void Start()
    {
        quiz.gameObject.SetActive(true);
        endScript.gameObject.SetActive(false);
    }


    void Update()
    {
        if (quiz.isComplete)
        {
            quiz.gameObject.SetActive(false);
            endScript.gameObject.SetActive(true);
            endScript.ShowFinalText();
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}