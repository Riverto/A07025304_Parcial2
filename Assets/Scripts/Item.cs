using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//	This class will help us control the behavior of several types of bricks
public class Item : MonoBehaviour {
    //	Public properties
    public static int itemCount = 0;
    //	Private properties
    private LevelManager levelManager;


	// Use this for initialization
	void Start () {
        itemCount++;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player1" || collision.collider.tag == "Player2")
        {
            itemCount--;
            levelManager.pickedUpItem(collision.collider.tag);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "death")
        {
            itemCount--;
            Destroy(gameObject);
        }
    }
}
