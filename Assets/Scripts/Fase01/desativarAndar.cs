using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desativarAndar : MonoBehaviour
{
    public GameObject parede;
    public GameObject chao;
    public GameObject objetos;
    public GameObject mae;

    public bool boxCima;

    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            //StartCoroutine(WaitForSeconds());
            parede.SetActive(!parede.activeSelf);
            chao.SetActive(!chao.activeSelf);
            objetos.SetActive(!objetos.activeSelf);
            mae.SetActive(!mae.activeSelf);

            this.transform.position = boxCima? new Vector3 (-5.17999983f,0.75999999f,0.119999997f): new Vector3(-5.17999983f,3.26999998f,-2.43899989f);
            boxCima = !boxCima;
        }
    }

    private IEnumerator WaitForSeconds() {
        yield return new WaitForSeconds(2);
    }
}
