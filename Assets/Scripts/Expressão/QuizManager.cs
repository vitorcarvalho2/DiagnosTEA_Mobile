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
    public TextMeshProUGUI QuestionTxt; // texto da pergunta
    private float writingSpeed = 0.05f;
    public TextMeshProUGUI ScoreTxt; // texto de pontuação
    public GameObject QuizPanel, EndPanel; // painel principal e painel final
    public int CurrentQuestion; // pergunta atual
    int TotalQuestion = 0; // quantidade de perguntas
    public int Score = 0; // pontuação
    private Coroutine displayCoroutine; // Armazena o Coroutine da pergunta atual


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
    void GenerateQuestion()
    {
        if (QnA.Count > 0)
        {
            CurrentQuestion = Random.Range(0, QnA.Count); // questao aleatoria
            if (displayCoroutine != null)
            {
                StopCoroutine(displayCoroutine);
            }
            displayCoroutine = StartCoroutine(DisplayQuestion(QnA[CurrentQuestion].Question)); // escreve a pergunta letra a letra
            SetAnswers(); // define as opções
            AnswersScript answer = options[CurrentQuestion].GetComponent<AnswersScript>(); // pega o script das opções
            answer.StartAnswerTimer(); // inicia o temporizador
        }
        else
        {
            FimDeJogo();
        }
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


    private IEnumerator DisplayQuestion(string question)
    {
        QuestionTxt.text = ""; // limpa o texto antes de começar a escrever

        foreach (char letter in question) // itera por cada letra na pergunta
        {
            QuestionTxt.text += letter; // adiciona a letra ao texto
            yield return new WaitForSeconds(writingSpeed); // espera um pouco antes de adicionar a próxima letra
        }
        displayCoroutine = null;
    }

    void VoltaJogo()
    {
        SceneManager.LoadScene("fase01");
    }

    void FimDeJogo()
    {
        QuizPanel.SetActive(false);
        //adicionar tempo padronizado
        StartCoroutine(PainelFimDeJogo());
    }

    private IEnumerator PainelFimDeJogo()
    {
        yield return new WaitForSeconds(1.5f);
        ScoreTxt.text = $"Acertos {Score}/{TotalQuestion}";
        EndPanel.SetActive(true);
    }
}
