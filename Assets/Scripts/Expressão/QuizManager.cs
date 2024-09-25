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
    private float writingSpeed = 0.02f;
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
            StartCoroutine(DisplayQuestion(QnA[CurrentQuestion].Question)); // escreve a pergunta letra a letra
            SetAnswers(); // define as opções
            AnswersScript answer = options[CurrentQuestion].GetComponent<AnswersScript>(); // pega o script das opções
            answer.StartAnswerTimer(); // inicia o temporizador
        }
        else
        {
            FimDeJogo();
        }
    }

    private IEnumerator DisplayQuestion(string question)
    {
        QuestionTxt.text = ""; // limpa o texto antes de começar a escrever
        foreach (char letter in question) // itera por cada letra na pergunta
        {
            QuestionTxt.text += letter; // adiciona a letra ao texto
            yield return new WaitForSeconds(writingSpeed); // espera um pouco antes de adicionar a próxima letra
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
