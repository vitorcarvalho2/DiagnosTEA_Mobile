using System;
using Unity.VisualScripting;
using UnityEngine;

public class AnswersScript : MonoBehaviour
{
    public Boolean IsCorrect = false;
    public QuizManager quizManager;
    private float answerStartTime;

    public void StartAnswerTimer()
    {
        answerStartTime = Time.time;
    }


    public void Answers()
    {
        
        float answerTimeElapsed = Time.time - answerStartTime;
        if (IsCorrect)
        {
            Debug.Log("Write, Question time:"+ answerTimeElapsed);
            quizManager.Correct();
        }
        else
        {    
            Debug.Log("Wrong, Question time:"+ answerTimeElapsed);
            quizManager.Wrong();
        }
    }

}
