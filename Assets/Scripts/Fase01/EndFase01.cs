using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFase01 : MonoBehaviour
{
    [SerializeField]
    SceneInfo sceneInfo;

    void Start()
    {
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
}

