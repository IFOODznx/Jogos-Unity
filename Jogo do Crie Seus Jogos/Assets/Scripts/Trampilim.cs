using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampilim : MonoBehaviour
{
    private Animator anim;
    public float forcaPuloTrampolim;    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Pulo");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, forcaPuloTrampolim), ForceMode2D.Impulse);
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }
}
