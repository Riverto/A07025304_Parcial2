using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocity;
    Vector2 direction = Vector2.right;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();;
    }

    void Update()
    {
        rb.velocity = velocity * direction; 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "border")//si choca contra el borde de la pantalla
        {
            Flip();//cambiar de direccion
        }
        if (collision.collider.tag == "Player1")//si choca contra un jugador, matarlo
        {
            GameObject.FindGameObjectWithTag(collision.collider.tag).GetComponent<PlayerController>().death();
        }
        if (collision.collider.tag == "Player2")//si choca contra un jugador, matarlo
        {
            GameObject.FindGameObjectWithTag(collision.collider.tag).GetComponent<PlayerController1>().death();
        }
    }

    private void Flip()
    {
        //volteamos el sprite
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
        //volteamos nuestra direccion
        direction = new Vector2(-1 * direction.x, direction.y);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "flip") Flip();
    }

    }
