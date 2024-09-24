
using UnityEngine;

public class ChooseChar : MonoBehaviour
{
    string prefabName;

    [SerializeField]
    public SceneInfo sceneInfo;

    // Start is called before the first frame update
    void Start()
    {
        // Cria o objeto
        prefabName = "Personagens/" + PlayerPrefs.GetString("charName").Split("(Clone)")[0];
        Vector3 playerPosition = sceneInfo.position;
        sceneInfo.playerName = prefabName;
        Instantiate((GameObject)Resources.Load(prefabName, typeof(GameObject)), playerPosition, Quaternion.identity);
    }

}