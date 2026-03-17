using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serra : MonoBehaviour
{
    public float velocidadeSerra;
    public float tempoDeMovimento;
    private bool movendoDireita = true;
    private float timer;

    void Update()
    {
        if (movendoDireita)
        {
            // Move a serra para a direita (se for verdadeiro)
            transform.Translate(Vector2.right * velocidadeSerra * Time.deltaTime);
        }
        else
        {
            // Move a serra para a esquerda (se for falso)
            transform.Translate(Vector2.left * velocidadeSerra * Time.deltaTime);
        }

        timer += Time.deltaTime;

        if(timer >= tempoDeMovimento)
        {
            // Inverte a direção do movimento
            movendoDireita = !movendoDireita;
            timer = 0f; // Reinicia o timer
        }

    }
}
