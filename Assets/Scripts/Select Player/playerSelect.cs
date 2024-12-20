using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playerSelect : MonoBehaviour
{

    GameObject player, playerCena;

    int i;

    public GameObject[] players;
    public Button next, previous, select, home;

    [SerializeField]
    public SceneInfo sceneInfo;
    float elapsedTime;
    public bool tempoBool = false;
    public Text tempoTexto;

    void Start()
    {
        Camera cameraCena = Camera.main;
        i = 0;
        tempoBool = true;
        next.onClick = new Button.ButtonClickedEvent();
        previous.onClick = new Button.ButtonClickedEvent();
        select.onClick = new Button.ButtonClickedEvent();
        home.onClick = new Button.ButtonClickedEvent();

        next.onClick.AddListener(() => Next());
        previous.onClick.AddListener(() => Previous());
        select.onClick.AddListener(() => Select());
        home.onClick.AddListener(() => Home());

    }

    void Update()
    {
        if (tempoBool)
        {
            elapsedTime += Time.deltaTime;
            int min = Mathf.FloorToInt(elapsedTime / 60);
            int sec = Mathf.FloorToInt(elapsedTime % 60);
            tempoTexto.text = string.Format("Tempo: {0:00}:{1:00}", min, sec);
        }
        if (!player)
        {
            player = GameObject.Find("Player");
            player = Instantiate(players[i], player.transform.position, player.transform.rotation);
        }
    }
    void Next()
    {
        i++;
        if (i >= players.Length)
        {
            i = 0;
        }

        Destroy(player);
    }

    void Previous()
    {
        i--;
        if (i < 0)
        {
            i = players.Length - 1;
        }

        Destroy(player);
    }

    void Select()
    {
        //declara posição inical do jogador no quarto e zera lista de objetos destruidos
        sceneInfo.position = new Vector3(-7.67f, 3.44f, 0.5f);
        sceneInfo.Limpar();

        tempoBool = false;
        sceneInfo.tempoPersonagens = tempoTexto.text;
        PlayerPrefs.SetString("charName", player.name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Home()
    {
        SceneManager.LoadScene("01_Menu");

    }
}
