using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    void Start()
    {
        // Initialize the score text
        scoreText.text = "Score: " + score.ToString();
    }

    // Call this method whenever the player gets a kill
    public void AddKill()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    }
}
