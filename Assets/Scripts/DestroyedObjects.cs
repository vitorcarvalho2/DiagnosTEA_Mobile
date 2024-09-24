
using UnityEngine;
using UnityEngine.UI;

public class DestroyedObjects : MonoBehaviour
{

    [SerializeField]
    public SceneInfo sceneInfo;
    public Image MochilaOff, LivroOff, LancheOff;

    //no começo da cena fase 1 são verificadas as listas de objetos a serem destruidas 
    void Start()
    {
        for (int i = 0; i < sceneInfo.destroyedObjects.Count; i++)
        {
            if (GameObject.Find(sceneInfo.destroyedObjects[i]) != null && GameObject.Find(sceneInfo.destroyedDialogs[i]) != null)
            {
                Destroy(GameObject.Find(sceneInfo.destroyedObjects[i]));
                Destroy(GameObject.Find(sceneInfo.destroyedDialogs[i]));
            }
        }
        // for de UI images the objects were referenced because the Find method don't work properly in children nodes.
        for (int i = 0; i < sceneInfo.disabledImages.Count; i++)
        {
            if (sceneInfo.disabledImages[i] != null)
            {
                if (sceneInfo.disabledImages[i] == "MochilaOff")
                {
                    MochilaOff.enabled = false;
                }
                if (sceneInfo.disabledImages[i] == "LivroOff")
                {
                    LivroOff.enabled = false;
                }
                if (sceneInfo.disabledImages[i] == "LancheOff")
                {
                    LancheOff.enabled = false;
                }
                else
                {
                }
            }
        }
    }
}
