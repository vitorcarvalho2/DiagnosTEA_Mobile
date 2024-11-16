using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFase01 : MonoBehaviour
{
    [SerializeField]
    SceneInfo sceneInfo;
    public GameObject itens;


    void Start()
    {
        if (sceneInfo.destroyedObjects.Count > 0 && sceneInfo.destroyedObjects.Count < 3)
        {
            StartCoroutine(ShowItens());
        }
        if (sceneInfo.destroyedObjects.Count == 3)
        {
            StartCoroutine(EndFase());
        }
    }

    IEnumerator EndFase()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Fim");
    }

    IEnumerator ShowItens()
    {
        yield return new WaitForSeconds(0.1f);
        itens.SetActive(true);
        yield return new WaitForSeconds(3f);
        itens.SetActive(false);

    }
}

