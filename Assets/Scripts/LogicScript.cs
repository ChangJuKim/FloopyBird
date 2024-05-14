using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private BirdScript bird;
    [SerializeField] private AudioSource audioSource;
    private int playerScore;
    private int previousHighScore;

    private void Start()
    {
        previousHighScore = PlayerPrefs.GetInt(Constants.HIGH_SCORE_KEY);
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        if (bird.GetIsAlive())
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            UpdateHighScore(playerScore);
            audioSource.Play();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.GetComponent<ScoreScript>().SetGameOverText(playerScore, previousHighScore);
        gameOverScreen.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void UpdateHighScore(int score)
    {
        if (score > PlayerPrefs.GetInt(Constants.HIGH_SCORE_KEY))
        {
            PlayerPrefs.SetInt(Constants.HIGH_SCORE_KEY, score);
        }
    }
}
