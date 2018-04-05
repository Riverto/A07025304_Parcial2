using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatCounter : MonoBehaviour {
    public GameObject stats;
    public int P1lives,P2lives;
    public int initLives;
    public int points;
    public int startPoints;
    public int P1score,P2score;
    public int HighScore;
    private int clears;
    public Text currentP1Lives;
    public Text currentP2Lives;
    public Text currentP1Points;
    // Use this for initialization
    void Start () {
        P1lives = P2lives = initLives;
        clears = 0;
        P2score = P1score = 0;
        points = 0;
        HighScore = 0;
        stats = GameObject.Find("Stats");
        //  If the instance is null, then we instanciate this GameObject
        //  and set it to not be destroyed when changing scenes
        if (stats == null)
        {
            stats = this.gameObject;
            stats.name = "Stats";
            DontDestroyOnLoad(stats);
        }
        else
        //if the instance is not null, then we destroy this GameObject
        {
            Destroy(this.gameObject);
        }
        Update();
    }
	
	// Update is called once per frame
	void Update () {
        currentP1Lives.text = "LIVES:" + P1lives;
        currentP2Lives.text = "LIVES:" + P2lives;
        //currentP1Points.text = "POINTS:" + P1score;
    }

    //Al perder una vida
    public void LostLife(string playerTag)
    {
        if(playerTag == "Player1")
        {
            P1lives--;
        }
        else
        {
            P2lives--;
        }
        //Decrementamos las vidas
        
        Update();
    }

    //Al perder todas las vidas o no querer continuar
    public void restart()
    {
        //reiniciamos el score y vidas
        P1score = P2score = 0;
        P1lives = P2lives = initLives;
    }

    public void passedLevel()
    {
        P1lives = P2lives = initLives;
    }

    public int getLives(string playerTag)
    {
        if (playerTag == "Player1")
        {
            return P1lives;
        }
        else return P2lives;
    }

    public void gotItem(string playerTag)
    {
        if (playerTag == "Player1")
        {
            P1score += 1;
        }
        else P2score += 1;
    }

    /*
    //Cuando el jugador llega a la cima
    public void reachedTop()
    {
        //incrementamos clear
        clears++;
        //sumamos sus puntos al score
        score += points;
        //damos un bonus por numero de clears
        score += 1000 * clears;
        //reiniciamos sus puntos
        points = 0;
        //y si su score es mayor al highscore
        if (score > HighScore)
        {
            //guardamos el nuevo highscore
            HighScore = score;
        }
    }

    //Cuando el jugador llega a una puerta (pasa de un nivel a otro)
    public void reachedDoor()
    {
        //guardamos los puntos con los que llego
        startPoints = points;
    }*/
}
