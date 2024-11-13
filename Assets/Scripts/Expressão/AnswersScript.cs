using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AnswersScript : MonoBehaviour
{
    //public Boolean IsCorrect = false;
    public QuizManager quizManager;
    private float answerStartTime;
    public TextMeshProUGUI answerText; 



    public void Answers()
    {   
        // if (IsCorrect)
        // {
        //     quizManager.Correct();
        // }
        // else
        // {
        //     quizManager.Wrong();
        // }
        quizManager.StoreAnswer(answerText.text); // Passa o texto para o QuizManager
        quizManager.NextQuestion();
    }

}
