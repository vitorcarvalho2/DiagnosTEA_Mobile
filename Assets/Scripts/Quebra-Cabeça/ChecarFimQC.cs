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

    void Start()
    {
        cronometro = 0;
        completou = false;
        objetos = FindObjectsOfType<ControllerPuzzle>();
        voltaJogo.onClick = new Button.ButtonClickedEvent();
        voltaJogo.onClick.AddListener(() => VoltaJogo());
    }

    void Update()
    {
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
        Tempo.instanciar.FimTempo();
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
        fimDeJogo.SetActive(true);
    }

}
