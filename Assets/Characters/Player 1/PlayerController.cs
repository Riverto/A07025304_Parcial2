using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public LevelManager levelmanager;

    public float maxVel = 5f;
    public float yJumpForce = 300f;

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 jumpForce;
    private bool isJumping = false;
    private bool movingRight = true;
    public Vector3 initPos;

    public bool holdingItem;
    public bool itemReachable;
    public GameObject item;

    public bool inDropZone;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        jumpForce = new Vector2(0, 0);

        initPos = gameObject.transform.position;

        holdingItem = false;
        inDropZone = false;

        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
        float v = Input.GetAxis("HorizontalP1");
        Vector2 vel = new Vector2(0, rb.velocity.y); //Mono cambia de fuerzas

        v *= maxVel;

        vel.x = v; //Vector con velocidad horizontal calculada

        rb.velocity = vel;

        //We change animations if needed
        if (v != 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        //if the player jumps
        if (Input.GetButtonDown("JumpP1"))
        {
            if (!isJumping)
            {
                if (rb.velocity.y == 0)
                {
                    anim.SetBool("isJumping", true);
                    isJumping = true;
                    jumpForce.x = 0f;
                    jumpForce.y = yJumpForce;
                    rb.AddForce(jumpForce);
                }
            }
        }
        else if(rb.velocity.y == 0) {
            isJumping = false;
            anim.SetBool("isJumping", false);
        }

        if (movingRight && v < 0)
        {
            movingRight = false;
            Flip();
        }
        else if (!movingRight && v > 0)
        {
            movingRight = true;
            Flip();
        }
    }

    private void Flip()
    {
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    public void Respawn()
    {
        gameObject.transform.position = initPos;
    }
    //cuando el jugador muere
    public void death()
    {
        //llamamos el metodo playerDied en levelManager
        levelmanager.playerDied(tag);
    }
}
