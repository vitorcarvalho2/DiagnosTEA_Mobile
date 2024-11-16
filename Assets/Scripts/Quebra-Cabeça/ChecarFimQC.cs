using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChecarFimQC : MonoBehaviour
{
    public bool completou;
    float cronometro;

    public GameObject fimDeJogo, imagemCompleta;

    [SerializeField]
    public SceneInfo sceneInfo;

    public Button voltaJogo;

    ControllerPuzzle[] objetos;

    public Text tempo;
    float elapsedTime;
    public bool tempoBool = false;

    void Start()
    {
        elapsedTime = 0f;
        tempoBool = true;
        cronometro = 0;
        completou = false;
        objetos = FindObjectsOfType<ControllerPuzzle>();
        voltaJogo.onClick = new Button.ButtonClickedEvent();
        voltaJogo.onClick.AddListener(() => VoltaJogo());
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
        cronometro += Time.deltaTime;
        if (cronometro >= 0.2f)
        {
            cronometro = 0;
            int soma = 0;
            for (int j = 0; j < objetos.Length; j++)
            {
                if (objetos[j].conectada)
                {
                    soma++;
                }
            }
            if (soma >= objetos.Length)
            {
                completou = true;
                FimDeJogo();
            }
        }
    }

    void FimDeJogo()
    {
        imagemCompleta.SetActive(true);
        StartCoroutine(PainelFimDeJogo());
    }

    void VoltaJogo()
    {
        SceneManager.LoadScene("fase01");
    }

    private IEnumerator PainelFimDeJogo()
    {
        yield return new WaitForSeconds(2);
        tempoBool = false;
        fimDeJogo.SetActive(true);
        sceneInfo.tempoQC = tempo.text;
    }

}
