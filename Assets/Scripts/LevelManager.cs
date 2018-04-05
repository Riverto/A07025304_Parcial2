using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        //Debug.Log ("New Level load: " + name);
        //  Load the scene requested
        //	Application.LoadLevel (name);    -- This method was deprecated a long time ago
        SceneManager.LoadScene(name);
    }

    public void EndGame()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    //  We added these functions to our previous LevelManager script.
    public void LoadNextLevel()
    {
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        Debug.Log("load next level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        stats.passedLevel();
    }

    //  Cuando el jugador muere
    public void playerDied(string playerTag)
    {
        //buscamos el objeto stats
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        //y llamamos el metodo LostLife
        stats.LostLife(playerTag);
        //si el jugador aun tiene vidas

        if (stats.getLives(playerTag)>0)
        {
            if (playerTag == "Player1")
            {
                GameObject.FindWithTag(playerTag).GetComponent<PlayerController>().Respawn();
            }
            else if (playerTag == "Player2")
            {
                GameObject.FindWithTag(playerTag).GetComponent<PlayerController1>().Respawn();
            }
        }
        else //si ya no tiene vidas restantes
        {
            //cargamos la escena de perdida
            LoadLevel("lose");
        }
    }
    /*
    //cuando el jugador llega a una puerta
    public void playerReachedDoor()
    {
        //buscamos el objeto stats
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        //llamamos el metodo reachedDoor
        stats.reachedDoor();
        //y cargamos el siguiente nivel
        LoadNextLevel();
    }

    //cuando el jugador llega a la cima
    public void playerReachedTop()
    {
        //buscamos el objeto stats
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        //lamamos el metodo reachedTop
        stats.reachedTop();
        //y cargamos la escena de ganar
        LoadLevel("Win");
    }
    */
    public void droppedItem(string playerTag)
    {
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        stats.gotItem(playerTag);
    }
    //cuando el jugador ya no quiere continuar o quiere salir
    public void returnToMenu()
    {
        //buscamos el objeto stats
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        //lamamos el metodo restart
        stats.restart();
        //y cargamos la escena Start
        LoadLevel("Start");
    }
}
