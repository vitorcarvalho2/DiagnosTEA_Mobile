using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class boxMinigameExpr : MonoBehaviour
{
    public GameObject painel;
    public Button start, close;

    [SerializeField]
    public SceneInfo sceneInfo;


    void Start()
    {
        painel.SetActive(false);

        start.onClick.AddListener(() => StartJogo());
        close.onClick.AddListener(() => FecharJogo());

    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {

            painel.SetActive(true);
            sceneInfo.position = col.transform.position;

        }
    }

    private void StartJogo()
    {
        sceneInfo.disabledImages.Add("LivroOff");
        sceneInfo.destroyedDialogs.Add("DialogAreaIrmao");
        sceneInfo.destroyedObjects.Add("Livro");

        SceneManager.LoadScene("Jogo_expressoes");

    }

    private void FecharJogo()
    {
        painel.SetActive(false);

    }

}
