using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCaida : MonoBehaviour
{
    public float tempoQueda;
    private TargetJoint2D target;
    private BoxCollider2D boxCollider;

    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("Caindo", tempoQueda);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }
    void Caindo()
    {
        target.enabled = false;
        boxCollider.isTrigger = true;
    }
}
