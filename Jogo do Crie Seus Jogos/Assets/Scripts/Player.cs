using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade;
    private Rigidbody2D rb;
    public float ForcaPulo;
    public bool isPulo;
    public bool puloDuplo;
    private Animator anim;


    void Start()
    {
        //Pegar o componente do Rigidbody2D do player
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movimento();
        Pulo();
    }

    //Movimentação do player
    void Movimento()
    {
        //Pegar o input do player para movimentação horizontal e criar um vetor de movimento
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //Aplicar o movimento ao player multiplicando pela velocidade e pelo tempo
        transform.position += Time.deltaTime * velocidade * movimento;
        
        //Verificar se o player está se movendo para a direita ou para a esquerda e ajustar a animação
        if(Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("Andando", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        
        //Verificar se o player está se movendo para a direita ou para a esquerda e ajustar a animação
        if(Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("Andando", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        
        //Verificar se o player parou de se mover e ajustar a animação
        if(Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("Andando", false);
        }
    }

    //Pulo do player
    void Pulo()
    {
        //Pegar o input do player para pular e verificar se ele está no chão
        if(Input.GetButtonDown("Jump"))
        {
            if (!isPulo)
            {
                //Aplicar uma força para o player pular
                rb.AddForce(new Vector2(0f, ForcaPulo), ForceMode2D.Impulse);
                puloDuplo = true;
                anim.SetBool("Pulando", true);
            }
            else
            {
                if (puloDuplo)
                {
                    //Aplicar uma força para o player pular novamente
                    rb.AddForce(new Vector2(0f, ForcaPulo), ForceMode2D.Impulse);
                    puloDuplo = false;
                }
            }
        }
    }

    //Detectar se o player está no chão ou não
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Verificar se o player colidiu com um objeto do chão (layer 8)
        if(collision.gameObject.layer == 8)
        {
            isPulo = false;
            anim.SetBool("Pulando", false);
        }

        if(collision.gameObject.tag == "Espinhos")
        {
            GameController.instance.GameOver();
            Destroy(gameObject);
        }
    }

    //Detectar se o player saiu do chão ou não
    void OnCollisionExit2D(Collision2D collision)
    {
        //Verificar se o player saiu de um objeto do chão (layer 8)
        if(collision.gameObject.layer == 8)
        {
            isPulo = true;
        }
    }
}
