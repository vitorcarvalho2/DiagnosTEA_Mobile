
using UnityEngine;
using System.Collections;


public class ChooseChar : MonoBehaviour
{
    string prefabName;

    [SerializeField]
    public SceneInfo sceneInfo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayedExecution());
        
    }

    IEnumerator DelayedExecution()
    {
        yield return new WaitForSeconds(0.2f); // Aguarda 2 segundos

        // Cria o objeto
        prefabName = "Personagens/" + PlayerPrefs.GetString("charName").Split("(Clone)")[0];
        Vector3 playerPosition = sceneInfo.position;
        sceneInfo.playerName = prefabName;
        Instantiate((GameObject)Resources.Load(prefabName, typeof(GameObject)), playerPosition, Quaternion.identity);
    }
}