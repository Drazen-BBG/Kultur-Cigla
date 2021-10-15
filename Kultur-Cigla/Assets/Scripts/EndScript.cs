using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EndScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winText;
    private ScoreKeeper scoreKeeper;
    
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }


    public void ShowFinalText()
    {
        winText.text = "Čestitamo! \nVaš rezultat je:" + scoreKeeper.CalculateScore() + "%";
    }
}
