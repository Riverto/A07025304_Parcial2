using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win_Screen : MonoBehaviour {
    public Text ScoreLabel;
    public StatCounter stats;

    private string winner;
	// Use this for initialization
	void Start () {
        stats = GameObject.Find("Stats").GetComponent<StatCounter>();

        if (stats.singlePlayer)
        {
            ScoreLabel.text = "You Won! \n Score: " + stats.P1score;
        } else
        {
            if (stats.P1lives == 0)
            {
                winner = "Player 2 Won!\n";
            } else if (stats.P2lives == 0)
            {
                winner = "Player 1 Won!\n";
            } else if (stats.P1score > stats.P2score)
            {
                winner = "Player 1 Won!\n";
            }
            else winner = "Player 2 Won!\n";
            ScoreLabel.text = winner + "Score Player 1: " + stats.P1score + "\nScore Player 2: " + stats.P2score;
        }

        /*
        //Busca el objeto stats que contiene el score y highscore
        stats = GameObject.Find("Stats").GetComponent<StatCounter>();
        //Y lo muestra en pantalla usando labels
        ScoreLabel.text = "Score: " +stats.score;
        HighScoreLabel.text = "HighScore: " + stats.HighScore;
        */
    }
}
