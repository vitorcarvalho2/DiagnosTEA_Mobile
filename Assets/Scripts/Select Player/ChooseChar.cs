
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
        StartCoroutine(SetPlayer());

    }

    IEnumerator SetPlayer()
    {
        yield return new WaitForSeconds(0.2f); // Aguarda 0.2 segundos para verificar os objetos destruidos

        // Cria o objeto
        prefabName = "Personagens/" + PlayerPrefs.GetString("charName").Split("(Clone)")[0];
        Vector3 playerPosition = sceneInfo.position;
        sceneInfo.playerName = prefabName;
        Instantiate((GameObject)Resources.Load(prefabName, typeof(GameObject)), playerPosition, Quaternion.identity);
    }
}