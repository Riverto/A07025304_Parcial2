using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject levelmanager;

    void Update()
    {
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        if (SceneManager.GetActiveScene().name.Contains("SP"))
        {
            stats.singlePlayer = true;
        }
        else stats.singlePlayer = false;
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void EndGame()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    //  We added these functions from our previous LevelManager script.
    public void LoadNextLevel()
    {
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        stats.passedLevel();
        Debug.Log("load next level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //  Cuando el jugador muere
    public void playerDied(string playerTag)
    {
        //buscamos el objeto stats
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        //y llamamos el metodo LostLife
        stats.LostLife(playerTag);
        
        if (stats.getLives(playerTag) > 0)
        {
            if (playerTag == "Player1")//lo reaparecemos
            {
                GameObject.FindWithTag(playerTag).GetComponent<PlayerController>().Respawn();
            }
            else if (playerTag == "Player2")//lo reaparecemos
            {
                GameObject.FindWithTag(playerTag).GetComponent<PlayerController1>().Respawn();
            }
        } else if (stats.singlePlayer)
        {
            LoadLevel("Lose");
        }
        else
        {
            LoadLevel("Win");
        }
        
    }

        //cuando el jugador recoge un item
    public void pickedUpItem(string playerTag)
    {
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        stats.gotItem(playerTag);
        //si ya no hay items
        if (Item.itemCount <= 0)
        {
            Debug.Log(stats.singlePlayer);
            if (stats.singlePlayer)
            {
                //Si es singleplayer se carga el siguiente nivel
                LoadNextLevel();
            } else LoadLevel("Win");
            //si es multijugador se carga win
        }

    }
    //cuando el jugador ya no quiere continuar o quiere salir
    public void returnToMenu()
    {
        //buscamos el objeto stats
        StatCounter stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        //lamamos el metodo restart
        stats.restart();
        //y cargamos la escena Start
        LoadLevel("Menu");
    }
}
