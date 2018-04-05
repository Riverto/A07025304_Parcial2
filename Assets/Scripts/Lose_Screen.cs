using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose_Screen : MonoBehaviour {

    public Text ScoreLabel;
    public StatCounter stats;

    // Use this for initialization
    void Start () {
        stats = GameObject.Find("Stats").GetComponent<StatCounter>();

        ScoreLabel.text = "Score: " + stats.P1score;
    }
}
