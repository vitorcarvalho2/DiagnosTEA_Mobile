using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int movimentos_Memoria;
    public int tempo_Memoria;
    public int tempo_QuebraCabeca;

    public Vector3 playerPosition;

    public GameData(){
        this.movimentos_Memoria = 0;
        this.tempo_Memoria = 0;
        this.tempo_QuebraCabeca = 0;
        //playerPosition = Vector3.zero;
    }
    
}
