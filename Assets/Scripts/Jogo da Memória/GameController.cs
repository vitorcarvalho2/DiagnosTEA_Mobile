using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour, IDataPersistence
{
    public GameObject fimDeJogo, pausePainel;
    public Text movimentos, movimentosFinal, tempoFinal;
    private int qtdMovimento;

    private Tempo tempo;
    
    [SerializeField]
    private Sprite bgImage;

    [SerializeField]
    public SceneInfo sceneInfo;

    public Sprite[] puzzles;

    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    private bool firstGuess,secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzle,secondGuessPuzzle;

    public Button voltaJogo;

    void Awake(){
        puzzles = Resources.LoadAll<Sprite>("Sprites/Cartas");

    }

    void Start() {
        fimDeJogo.SetActive(false);

        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles);

        gameGuesses = gamePuzzles.Count/2;
        movimentos.text = "Movimentos:  " + qtdMovimento;
                               
        Tempo.instanciar.IniciarTempo();

        voltaJogo.onClick = new Button.ButtonClickedEvent();

        voltaJogo.onClick.AddListener(() => VoltaJogo());

    }

    void GetButtons(){
        GameObject[] objects = GameObject.FindGameObjectsWithTag("botaoCard");

        for(int i = 0; i < objects.Length; i++){
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }

    void AddGamePuzzles(){
        int looper = btns.Count;
        int index = 0;

        for(int i = 0; i < looper; i++){
            if(index == looper/2){
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);
            index++;
        }

    }

    void AddListeners(){
             foreach (Button btn in btns)
            {
                btn.onClick.AddListener(() => PickPuzzle());
            }         
    }

    public void PickPuzzle(){
        if(!firstGuess){
            firstGuess = true;

            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;

            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];

        }else if(!secondGuess){
            secondGuess = true;

            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;

            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            countGuesses++;

            StartCoroutine(CheckIfThePuzzleMatch());
        }
    }

    IEnumerator CheckIfThePuzzleMatch(){
        yield return new WaitForSeconds(1f);

        if(firstGuessPuzzle == secondGuessPuzzle){
            yield return new WaitForSeconds(0.5f);

            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0,0,0,0);
            btns[secondGuessIndex].image.color = new Color(0,0,0,0);

            CheckIfTheGameIsFinished();  
        }else{
            yield return new WaitForSeconds(0.5f);

            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }

        //yield return new WaitForSeconds(0.5f);

        firstGuess = secondGuess = false;

        qtdMovimento++;

        movimentos.text = "Movimentos: " + qtdMovimento; 
    }

    void CheckIfTheGameIsFinished(){
        countCorrectGuesses++;

        if(countCorrectGuesses == gameGuesses){
            fimDeJogo.SetActive(true);
            movimentosFinal.text = "Movimentos: " + (qtdMovimento+1);
            Tempo.instanciar.FimTempo();
        }
    }

    void Shuffle(List<Sprite>list){
        for(int i = 0; i < list.Count; i++){
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list [randomIndex] = temp;
        }
    }

    void VoltaJogo(){
         SceneManager.LoadScene("fase01");            
    }

    public void LoadData(GameData data){
        this.qtdMovimento = qtdMovimento;
    }

    public void SaveData(ref GameData data){
        data.movimentos_Memoria =  this.qtdMovimento;
    }
}
