using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName ="SceneInfo",menuName ="Persistence")]
public class SceneInfo : ScriptableObject{
    //this class contains the information about player curent position and a list of destroyed objects, it has to be instanciated in every itembox
    //to collect position information and to add the object to the destoyed list. It also has to be added in each minigame end script like "checarFimQC"
    public Vector3 position;
    public string playerName;
   
    //list of minigame box objects
    public List<string> destroyedObjects = new List<string>();

    //list of dialogBox
    public List<string> destroyedDialogs = new List<string>();
    
    //list of inventory itens
    public List<string> disabledImages = new List<string>();
    
}
