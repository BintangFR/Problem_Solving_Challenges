using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int currentScore = 0;

    [SerializeField]
    private Text scoreText;

    private void Awake()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
    }

    public void IncreaseScore(int increase)
    {
        currentScore += increase;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + currentScore;
    }
}
