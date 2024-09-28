using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PainelFim : MonoBehaviour
{
    public Button exit, home;
    void Start()
    {
        exit.onClick = new Button.ButtonClickedEvent();
        home.onClick = new Button.ButtonClickedEvent();

        exit.onClick.AddListener(() => Exit());
        home.onClick.AddListener(() => Home());
    }

    void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Para parar o jogo no editor
#else
        Application.Quit(); // Para encerrar a build do jogo
#endif
    }

    void Home()
    {
        SceneManager.LoadScene("01_menu");
    }
}
