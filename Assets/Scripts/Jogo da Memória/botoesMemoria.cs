using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class botoesMemoria : MonoBehaviour
{
    public Button pause;
    public GameObject painel;

    private ChecarFimQC checarFimQC;

    private GameController gameController;

    private QuizManager quizManager;

    void Start()
    {
        pause.onClick = new Button.ButtonClickedEvent();

        pause.onClick.AddListener(() => Pause());

        //mesmo pause então busca os botoes mas so vai achar um
        checarFimQC = FindObjectOfType<ChecarFimQC>();

        gameController = FindObjectOfType<GameController>();

        quizManager = FindObjectOfType<QuizManager>();
    }

    public void Pause()
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
        painel.SetActive(true);
    }
}
