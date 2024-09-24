using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class ControllerPuzzle : MonoBehaviour
{
    Vector3 posicaoInicial;
    Vector3 posicaoDestino;
    Vector3 vetorDirecao;

    Rigidbody2D _rigidbody2d;
    
    bool arrastando;
    float distancia;

    [HideInInspector]
    public bool conectada;

    public Button pause;

    [Range(1, 15)]
    public float velocidadeDeMovimento = 10;

    public Transform conector;
    [Range(0.1f, 2.0f)]
    public float distanciaMinimaConector = 0.5f;

    void Start()
    {
        _rigidbody2d = transform.root.GetComponent<Rigidbody2D>();
        _rigidbody2d.gravityScale = 1;

        Tempo.instanciar.IniciarTempo();
    }
    
    private void OnMouseDown() {
        posicaoInicial = transform.root.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _rigidbody2d.gravityScale = 0;
        arrastando = true;
    } 

    private void OnMouseDrag() {
        posicaoDestino = posicaoInicial + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vetorDirecao = posicaoDestino - transform.root.position;
        _rigidbody2d.velocity = vetorDirecao * velocidadeDeMovimento;
    }

    private void OnMouseUp() {
        _rigidbody2d.gravityScale = 1;
        arrastando = false;
    } 

    private void FixedUpdate()
    {
        
        if(!arrastando && !conectada){
            distancia = Vector2.Distance(transform.root.position, conector.position);
            if(distancia < distanciaMinimaConector){
            _rigidbody2d.gravityScale = 0;
            _rigidbody2d.velocity = Vector2.zero;
            transform.root.position = Vector2.MoveTowards(transform.root.position,conector.position, 0.02f);
            }
            if(distancia < 0.01f){
                conectada = true;
                transform.root.position = conector.position;
                _rigidbody2d.isKinematic = true;
            }
        }
        
    }
}
