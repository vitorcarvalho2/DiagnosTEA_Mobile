using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Tempo : MonoBehaviour
{
    public static Tempo instanciar;

    public Text tempoTexto, tempoFinal;
    private TimeSpan tempoCronometro;
    private int cronometro;
    private bool tempoBool;
    private float tempoTransforma;
    
    void Awake(){
        instanciar = this;
    }

    void Start()
    {
        tempoTexto.text = "Tempo 00:00:00";
        tempoBool = false;
    }

    public void IniciarTempo(){
        tempoBool = true;
        tempoTransforma = 0f;

        StartCoroutine(ActUpdate());
    }

    public void FimTempo(){
        tempoBool = false;
        
    }

    public void ContinuarTempo()
    {
        // Retoma o cronômetro
        tempoBool = true;
        StartCoroutine(ActUpdate());
    }
    
    public void PausarTempo()
    {
        // Congela o cronômetro junto com o jogo
        tempoBool = false;
    }

    IEnumerator ActUpdate(){
        while(tempoBool){
            tempoTransforma += Time.deltaTime;
            tempoCronometro = TimeSpan.FromSeconds(tempoTransforma);
            string tempoStr = "Tempo "+ tempoCronometro.ToString("mm':'ss':'ff");
            tempoTexto.text = tempoStr;

            yield return null;
        }
        tempoFinal.text = tempoTexto.text;
    }
}
