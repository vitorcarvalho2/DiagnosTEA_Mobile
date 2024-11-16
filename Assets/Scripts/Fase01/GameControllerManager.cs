
using UnityEngine;
using UnityEngine.UI;

public class GameControllerManager : MonoBehaviour
{

    [SerializeField]
    public SceneInfo sceneInfo;
    public Image MochilaOff, LivroOff, LancheOff;
    public Button pauseButton;
    public GameObject painelPause;
    [SerializeField] private GameObject audioManager, mixerManager;
    //no começo da cena fase 1 são verificadas as listas de objetos a serem destruidas 
    void Start()
    {
        pauseButton.onClick = new Button.ButtonClickedEvent();
        pauseButton.onClick.AddListener(() => Pause());

        if (AudioManager.instance == null)
        {
            Instantiate(audioManager);
            Instantiate(mixerManager);
        }
        for (int i = 0; i < sceneInfo.destroyedObjects.Count; i++)
        {
            if (GameObject.Find(sceneInfo.destroyedObjects[i]) != null && GameObject.Find(sceneInfo.destroyedDialogs[i]) != null)
            {
                Destroy(GameObject.Find(sceneInfo.destroyedDialogs[i]));
                Destroy(GameObject.Find(sceneInfo.destroyedObjects[i]));
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

    public void Pause()
    {
        painelPause.SetActive(true);
    }
}
