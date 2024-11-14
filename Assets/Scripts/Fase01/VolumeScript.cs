using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class VolumeScript : MonoBehaviour
{
    public Button volume,voltar;
    public GameObject VolumePanel;

    void Start()
    {
        volume.onClick = new Button.ButtonClickedEvent();
        volume.onClick.AddListener(() => VolumeHandler());

        voltar.onClick = new Button.ButtonClickedEvent();
        voltar.onClick.AddListener(() => Voltar());
    }
    public void VolumeHandler()
    {
        VolumePanel.SetActive(true);
    }

    public void Voltar(){
        VolumePanel.SetActive(false);
    }
}
