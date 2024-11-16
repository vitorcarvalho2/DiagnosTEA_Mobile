using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PainelPause : MonoBehaviour
{
    public Button voltar, home, som;
    public GameObject painel;
    public GameObject VolumePanel;
    private ChecarFimQC checarFimQC;
    private GameController gameController;
    private QuizManager quizManager;
    void Start()
    {
        voltar.onClick = new Button.ButtonClickedEvent();
        home.onClick = new Button.ButtonClickedEvent();
        som.onClick = new Button.ButtonClickedEvent();

        voltar.onClick.AddListener(() => BackToGame());
        home.onClick.AddListener(() => Home());
        som.onClick.AddListener(() => Volume());

        checarFimQC = FindObjectOfType<ChecarFimQC>();
        gameController = FindObjectOfType<GameController>();
        quizManager = FindObjectOfType<QuizManager>();

        Pause();

    }

    void Pause()
    {
        if (checarFimQC != null)
        {
            checarFimQC.tempoBool = false;
        }
        if (gameController != null)
        {
            gameController.tempoBool = false;
        }
        if (quizManager != null)
        {
            quizManager.tempoBool = false;
        }
    }

    public void Home()
    {
        SceneManager.LoadScene("01_menu");
    }

    public void BackToGame()
    {
        if (checarFimQC != null)
        {
            checarFimQC.tempoBool = true;
        }
        if (gameController != null)
        {
            gameController.tempoBool = true;
        }
        if (quizManager != null)
        {
            quizManager.tempoBool = true;
        }
        painel.SetActive(false);
    }

     public void Volume()
    {
        VolumePanel.SetActive(true);
    }
}
