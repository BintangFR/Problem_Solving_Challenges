using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager9 : MonoBehaviour
{
    int currentScore = 0;
    private bool set;

    [SerializeField]
    private Text scoreText;
    public GameObject gameOver;
    public GameObject tutorial;

    private void Awake()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ShowTutorial(set);
            set = !set;
        }
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

    private void RestartGame()
    {
        SceneManager.LoadScene(9);
        Time.timeScale = 1;
    }

    private void ShowTutorial(bool set)
    {
        tutorial.gameObject.SetActive(set);
    }

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
