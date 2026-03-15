using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manzana : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circulo;
    public GameObject coletado;
    public int valorPontuacao;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circulo = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circulo.enabled = false; 
            coletado.SetActive(true);

            GameController.instance.totalPontuacao += valorPontuacao;
            GameController.instance.AtualizarPontuacao();

            Destroy(gameObject, 0.3f);
        }
    }
}
