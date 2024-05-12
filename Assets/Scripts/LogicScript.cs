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
    public void addScore(int scoreToAdd)
    {
        if (bird.isAlive())
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            audioSource.Play();
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
