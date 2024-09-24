using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PainelPause : MonoBehaviour
{
    public Button btg, home, pause;
    public GameObject painel;


    void Start()
    {
        btg.onClick = new Button.ButtonClickedEvent();
        home.onClick = new Button.ButtonClickedEvent();

        btg.onClick.AddListener(() => BackToGame());
        home.onClick.AddListener(() => Home());
    }

    public void Home (){
        SceneManager.LoadScene("01_menu");
    }

    public void BackToGame (){
        painel.SetActive(false);
        Tempo.instanciar.ContinuarTempo();
    }
}
