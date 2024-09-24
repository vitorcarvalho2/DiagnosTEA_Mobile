using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuizManager : MonoBehaviour
{
    public List<QuestionsandAnwers> QnA;//lista de perguntas
    public GameObject[] options; // array de opções de resposta
    public Text QuestionTxt; // texto da pergunta
    public Text ScoreTxt; // texto de pontuação
    public GameObject QuizPanel,EndPanel; // painel principal e painel final
    public int CurrentQuestion; // pergunta atual
    int TotalQuestion = 0; // quantidade de perguntas
    public int Score = 0; // pontuação

    [SerializeField]
    public SceneInfo sceneInfo;

    public Button voltaJogo;

    private void Start()//inicia o jogo deixando o painel principal visivel e os outros nao
    {
        voltaJogo.onClick = new Button.ButtonClickedEvent();
        voltaJogo.onClick.AddListener(() => VoltaJogo());
        TotalQuestion = QnA.Count; // coloca a quantidade de perguntas
        GenerateQuestion(); // gera a primeira pergunta aleatoria
    }

    void FimDeJogo()
    {   
        QuizPanel.SetActive(false);
        //adicionar tempo padronizado
        StartCoroutine(PainelFimDeJogo());
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
            FimDeJogo();
        }
    }

    void VoltaJogo()
    {
        SceneManager.LoadScene("fase01");
    }

    private IEnumerator PainelFimDeJogo()
    {
        yield return new WaitForSeconds(1.5f);
        ScoreTxt.text = $"Você acertou {Score}/{TotalQuestion} perguntas!";
        EndPanel.SetActive(true);
    }
}
