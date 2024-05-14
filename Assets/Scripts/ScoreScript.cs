using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private TMP_Text gameOverMessage;

    public void SetGameOverText(int score, int highScore)
    {
        string text = "Your score is " + score;
        if (score > highScore)
        {
            text += "\nYou beat your previous high score!";
        }
        gameOverMessage.text = text;
    }
}
