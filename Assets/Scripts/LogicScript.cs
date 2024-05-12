using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public BirdScript bird;
    public AudioSource audioSource;

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        if (bird.isAlive())
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            audioSource.Play();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
