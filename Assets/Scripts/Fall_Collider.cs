using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Collider : MonoBehaviour {
    public BoxCollider2D deathCollider;
	
	// Update is called once per frame
	void Update () {
        //se mueve el collider para que este en la orilla de la camara
	}

    //Cuando se toca este collider
    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("triggered");
        if(collider.tag == "Player1")
        {
            collider.gameObject.GetComponent<PlayerController>().death();
        } else if (collider.tag == "Player2"){
            collider.gameObject.GetComponent<PlayerController1>().death();
        }
        
    }
}
