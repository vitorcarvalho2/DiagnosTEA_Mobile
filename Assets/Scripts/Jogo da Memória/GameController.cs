using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour, IDataPersistence
{
    // pariaveis do painel 
    public GameObject fimDeJogo, pausePainel;
    public Text movimentos, movimentosFinal,tempoTexto, tempoFinal;
    private int qtdMovimento;

    [SerializeField]
    public SceneInfo sceneInfo;

    //variaveis do jogo
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] puzzles;

    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    //booleans to check if it is the first or second guess
    private bool firstGuess, secondGuess;

    int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzle, secondGuessPuzzle;

    public Button voltaJogo;

    void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites/Cartas");
    }

    void Start()
    {
        fimDeJogo.SetActive(false);
        GetButtons();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;

        movimentos.text = "Movimentos:  " + qtdMovimento;
        
        Tempo.instanciar.IniciarTempo();

        voltaJogo.onClick = new Button.ButtonClickedEvent();
        voltaJogo.onClick.AddListener(() => VoltaJogo());

    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("botaoCard");//pega todos os botoes com a tag

        for (int i = 0; i < objects.Length; i++)
        {
            Button btn = objects[i].GetComponent<Button>(); //atribui o botão ao botão
            btns.Add(btn); //adiciona o botão na lista
            
            int index = i;  // Captura o índice correto do botão
            btns[i].onClick.AddListener(() => PickPuzzle(index)); // Passa o índice para PickPuzzle 
            btn.image.sprite = bgImage;
        }
    }

    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);
            index++;
        }

    }

    public void PickPuzzle(int index)
    {
        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = index;
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;

            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];

        }
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = index;

            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;

            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            countGuesses++;

            StartCoroutine(CheckIfThePuzzleMatch());
        }
    }

    IEnumerator CheckIfThePuzzleMatch()
    {
        yield return new WaitForSeconds(1f);

        if (firstGuessPuzzle == secondGuessPuzzle)
        {
            yield return new WaitForSeconds(0.2f);

            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinished();
        }
        else
        {
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }

        yield return new WaitForSeconds(0.2f);

        firstGuess = secondGuess = false;
        qtdMovimento++;
        movimentos.text = "Movimentos: " + qtdMovimento;
    }

    void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;

        if (countCorrectGuesses == gameGuesses)
        {
            Tempo.instanciar.FimTempo();
            movimentosFinal.text = "Movimentos: " + (qtdMovimento + 1);
            fimDeJogo.SetActive(true);

        }
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    void VoltaJogo()
    {
        SceneManager.LoadScene("fase01");
    }

    public void LoadData(GameData data)
    {
        //this.qtdMovimento = qtdMovimento;
        
    }

    public void SaveData(ref GameData data)
    {
        data.movimentos_Memoria = this.qtdMovimento;
       
    }
}
