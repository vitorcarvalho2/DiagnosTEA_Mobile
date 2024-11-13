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
    public GameObject QuizPanel, EndPanel; // painel principal e painel final
    public int currentQuestion; // pergunta atual
    int totalQuestion = 0; // quantidade de perguntas
    [SerializeField]
    public SceneInfo sceneInfo;

    public Button voltaJogo;

    public TextMeshProUGUI tempo;
    float elapsedTime;
    public bool tempoBool = false;

    private void Start()
    {
        voltaJogo.onClick = new Button.ButtonClickedEvent();
        voltaJogo.onClick.AddListener(() => VoltaJogo());
        elapsedTime = 0f;
        tempoBool = true;
        totalQuestion = QnA.Count; // coloca a quantidade de perguntas
        GenerateQuestion();
    }

    void Update()
    {
        if (tempoBool)
        {
            elapsedTime += Time.deltaTime;
            int min = Mathf.FloorToInt(elapsedTime / 60);
            int sec = Mathf.FloorToInt(elapsedTime % 60);
            tempo.text = string.Format("Tempo: {0:00}:{1:00}", min, sec);
        }
    }

    public void NextQuestion()
    {   
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
        AnswersScript answer = options[currentQuestion].GetComponent<AnswersScript>();
    }

    public void StoreAnswer(string answer)
    {
        sceneInfo.respostasQuiz.Add(answer);
    }

    // public void Correct()
    // {
    //     Score += 1;
    //     QnA.RemoveAt(currentQuestion);
    //     GenerateQuestion();
    //     AnswersScript answer = options[currentQuestion].GetComponent<AnswersScript>();
    // }

    // public void Wrong()
    // {
    //     QnA.RemoveAt(currentQuestion);
    //     GenerateQuestion();
    //     AnswersScript answer = options[currentQuestion].GetComponent<AnswersScript>();
    // }
    void GenerateQuestion()
{
    if (QnA.Count > 0)
    {   
        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswers(); // define as opções
        AnswersScript answer = options[currentQuestion].GetComponent<AnswersScript>(); // pega o script das opções
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
            //options[i].GetComponent<AnswersScript>().IsCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            //if (QnA[currentQuestion].CorrectAnswer == i + 1){
                //options[i].GetComponent<AnswersScript>().IsCorrect = true;
            //}
        }
    }


    void VoltaJogo()
    {
        SceneManager.LoadScene("fase01");
    }

    void FimDeJogo()
    {
        QuizPanel.SetActive(false);
        tempoBool = false;
        StartCoroutine(PainelFimDeJogo());
    }

    private IEnumerator PainelFimDeJogo()
    {
        yield return new WaitForSeconds(1.5f);
        sceneInfo.tempoQuiz = tempo.text;
        EndPanel.SetActive(true);
    }
}
