using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade;
    private Rigidbody2D rb;
    public float ForcaPulo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movimento();
        Pulo();
    }

    void Movimento()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += Time.deltaTime * velocidade * movimento;
    }

    void Pulo()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0f, ForcaPulo), ForceMode2D.Impulse);
        }
    }
}