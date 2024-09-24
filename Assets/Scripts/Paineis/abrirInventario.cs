using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class abrirInventario : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Button iconInventario, fechar;

    void Start()
    {
        dialoguePanel.SetActive(false);
        iconInventario.onClick = new Button.ButtonClickedEvent();
        fechar.onClick = new Button.ButtonClickedEvent();

        iconInventario.onClick.AddListener(() => painelInventario());
        fechar.onClick.AddListener(() => fecharInventario());
    }
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Escape)){
            dialoguePanel.SetActive(false);
         }
    
    }

    void painelInventario(){
        dialoguePanel.SetActive(true);
    }

    void fecharInventario(){
        dialoguePanel.SetActive(false);

    }
}
