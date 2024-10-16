using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public Button load01, load02, load03, load04, home;

    private void Start()
    {
        load01.onClick = new Button.ButtonClickedEvent();
        load02.onClick = new Button.ButtonClickedEvent();
        load03.onClick = new Button.ButtonClickedEvent();
        load04.onClick = new Button.ButtonClickedEvent();
        home.onClick = new Button.ButtonClickedEvent();
        load01.onClick.AddListener(() => ComcecarJogo());
        load02.onClick.AddListener(() => ComcecarJogo());
        load03.onClick.AddListener(() => ComcecarJogo());
        load04.onClick.AddListener(() => ComcecarJogo());
        home.onClick.AddListener(() => Home());

    }

    /*
    public void OnNewGameClicked(){
        DataPersistenceManager.instance.NewGame();
    }

    public void OnLoadGameClicked(){
        DataPersistenceManager.instance.LoadGame();
    }

    public void OnSaveGameClicked(){
        DataPersistenceManager.instance.SaveGame();
    }*/

    public void ComcecarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Home()
    {
        SceneManager.LoadScene("01_Menu");
    }
}
