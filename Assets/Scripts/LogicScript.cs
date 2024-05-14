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
    private string highScoreKey;

    private void Start()
    {
        highScoreKey = !bool.Parse(PlayerPrefs.GetString(Constants.IS_FF_KEY)) ? Constants.CLASSIC_HIGH_SCORE_KEY : Constants.FF_HIGH_SCORE_KEY;
        previousHighScore = PlayerPrefs.GetInt(highScoreKey);
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
        if (score > PlayerPrefs.GetInt(highScoreKey))
        {
            PlayerPrefs.SetInt(highScoreKey, score);
        }
    }
}
