
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class boxMinigameQuebra : MonoBehaviour
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
        sceneInfo.destroyedObjects.Add("Lanche");
        sceneInfo.destroyedDialogs.Add("DialogAreaPai");
        sceneInfo.disabledImages.Add("LancheOff");
        SceneManager.LoadScene("Quebra_Cabeça");
    }

    private void FecharJogo()
    {
        painel.SetActive(false);

    }

}
