using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PainelFim : MonoBehaviour
{
    public Button exit, home, dados;
    public GameObject painelItens, painelDados;
    public Text btDadosTexto;
    public Text info;
    public SceneInfo sceneInfo;

    void Start()
    {
        exit.onClick = new Button.ButtonClickedEvent();
        home.onClick = new Button.ButtonClickedEvent();
        dados.onClick = new Button.ButtonClickedEvent();
        exit.onClick.AddListener(() => Exit());
        home.onClick.AddListener(() => Home());
        dados.onClick.AddListener(() => Dados());
        Info();
    }

    void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    }

void Info()
{   
    // Converte a lista de respostas  do quiz em uma string, separada por vírgulas
    string respostasQuizString = string.Join(", ", sceneInfo.respostasQuiz);
    
    // Monta a string final, incluindo as respostas formatadas
    string aux = "<b>Jogo da Memoria</b>\n" + sceneInfo.tempoMemo + " \n" + sceneInfo.movimentos + " \n"
        + "<b>Quebra Cabeça</b>\n" + sceneInfo.tempoQC + "\n"
        + "<b>Quiz</b>\n" + sceneInfo.tempoQuiz + " \n" 
        + "Respostas: \n" + respostasQuizString + " \n" 
        + "<b>Personagens:</b>\n" + sceneInfo.tempoPersonagens;
    info.text = aux;
}


    void Dados()
    {
        if (painelItens.activeSelf)
        {
            painelItens.SetActive(false);
            painelDados.SetActive(true);
            btDadosTexto.text = "Itens";
        }
        else if (painelDados.activeSelf)
        {
            painelItens.SetActive(true);
            painelDados.SetActive(false);
            btDadosTexto.text = "Estatisticas";
        }
    }

    void Home()
    {
        SceneManager.LoadScene("01_menu");
    }
}
