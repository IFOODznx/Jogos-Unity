using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inimiigo : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    public float velocidade;

    public Transform direita;
    public Transform esquerda;

    public Transform naCabeca;

    public bool colisao;

    public LayerMask layer;

    public BoxCollider2D box;

    public CircleCollider2D circle;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        rig.velocity = new Vector2(velocidade, rig.velocity.y);

        colisao = Physics2D.Linecast(direita.position, esquerda.position);

        if (colisao)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            velocidade = -velocidade;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            float altura = collision.contacts[0].point.y - naCabeca.position.y;

            if (altura > 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                velocidade = 0;
                anim.SetTrigger("Morte");
                box.enabled = false;
                circle.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 0.33f);
            }
        }
    }
}
