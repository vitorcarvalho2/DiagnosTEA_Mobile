using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    public Transform player;
    public Vector3 offSet;  
   
    void Start()
    {
        offSet = transform.position - player.position;
        // player = GameObject.Find(PlayerPrefs.GetString("charName")).transform;
    }

    void Update()
    {
        
    }

    private void LateUpdate() {
        transform.position = player.position + offSet;
    }

    public void setPlayer() {
        player = GameObject.Find(PlayerPrefs.GetString("charName")).transform.GetChild(0).transform;
    }
}
