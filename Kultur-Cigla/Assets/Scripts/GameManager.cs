using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScript endScript;
    void Start()
    {
        quiz = FindObjectOfType<Quiz>();
        endScript = FindObjectOfType<EndScript>();

        quiz.gameObject.SetActive(true);
        endScript.gameObject.SetActive(false);
    }


    void Update()
    {
        
    }
}
