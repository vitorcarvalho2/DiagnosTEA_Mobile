using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void PlayGame (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void QuitGame (){
        Debug.Log("SAIU");
        Application.Quit();
   }

   void StartJogo(){
       SceneManager.LoadScene("Jogo_da_Memoria");     
     }

}