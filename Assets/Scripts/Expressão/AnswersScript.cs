using System;
using UnityEngine;

public class AnswersScript : MonoBehaviour
{
    public Boolean IsCorrect = false;
    public QuizManager quizManager;
    private float answerStartTime;

    public void Answers()
    {
        if (IsCorrect)
        {
            quizManager.Correct();
        }
        else
        {
            quizManager.Wrong();
        }
    }

}
