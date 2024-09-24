using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsandAnwers> QnA;//lista de perguntas
    public GameObject[] options; // array de opções de resposta
    public TextMeshProUGUI QuestionTxt; // texto da pergunta
    public TextMeshProUGUI ScoreTxt; // texto de pontuação
    public TextMeshProUGUI ScoreTxt2; // texto de pontuação
    public GameObject QuizPanel; // painel principal
    public GameObject GoPanel; // painel final
    public GameObject EndPanel; // painel final
    public int CurrentQuestion;
    int TotalQuestion = 0;
    public int Score = 0;

    private void Start()//inicia o jogo deixando o painel principal visivel e os outros nao
    {
        QuizPanel.SetActive(true);
        GoPanel.SetActive(false);
        EndPanel.SetActive(false);
        TotalQuestion = QnA.Count; // coloca a quantidade de perguntas
        GenerateQuestion(); // gera a primeira pergunta aleatoria
    }

    

    void GameOver()
    { 
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = $"{Score}/{TotalQuestion}";
        
        Debug.Log("sem mais perguntas"+ Time.time);
    }
    public void Retry()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void End()
    {
        GoPanel.SetActive(false);
        EndPanel.SetActive(true);
        ScoreTxt2.text = $"{Score}/{TotalQuestion}";
    }
    public void Correct()
    {
        Score += 1;
        QnA.RemoveAt(CurrentQuestion);
        GenerateQuestion();
        AnswersScript answer = options[CurrentQuestion].GetComponent<AnswersScript>();
        


    }

    public void Wrong()
    {
        QnA.RemoveAt(CurrentQuestion);
        GenerateQuestion();
        AnswersScript answer = options[CurrentQuestion].GetComponent<AnswersScript>();
        

    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswersScript>().IsCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[CurrentQuestion].Answers[i];

            if (QnA[CurrentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswersScript>().IsCorrect = true;

            }
        }
    }

    void GenerateQuestion()
    {
        if (QnA.Count > 0)
        {
            CurrentQuestion = Random.Range(0, QnA.Count); // questao aleatoria
            QuestionTxt.text = QnA[CurrentQuestion].Question;
            SetAnswers();
            AnswersScript answer = options[CurrentQuestion].GetComponent<AnswersScript>();
            answer.StartAnswerTimer();
        }
        else
        {
            GameOver();
        }
    }



}
