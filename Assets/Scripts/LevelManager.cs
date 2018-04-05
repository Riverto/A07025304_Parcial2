using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject levelmanager;
    public bool singlePlayer = false;

    void Start()
    {
        levelmanager = GameObject.Find("levelManager");
        //  If the instance is null, then we instanciate this GameObject
        //  and set it to not be destroyed when changing scenes
        if (levelmanager == null)
        {
            levelmanager = this.gameObject;
            levelmanager.name = "levelManager";
            DontDestroyOnLoad(levelmanager);
        }
        else
        //if the instance is not null, then we destroy this GameObject
        {
            Destroy(this.gameObject);
        }
    }

    public void isSinglePlayer(bool boolean)
    {
        singlePlayer = boolean;
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
        } else if (singlePlayer)
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
        //si ya no hay items
        if (Item.itemCount <= 0)
        {
            if (singlePlayer)
            {
                //Si es singleplayer se carga el siguiente nivel
                LoadNextLevel();
            }
            //si es multijugador se carga win
            else LoadLevel("Win");
        }
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
        LoadLevel("Menu");
    }
}
