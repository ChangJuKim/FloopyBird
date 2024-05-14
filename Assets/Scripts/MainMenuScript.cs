using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void Play()
    {
        Debug.Log("Play game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void DeleteClassicHighScore()
    {
        PlayerPrefs.DeleteKey(Constants.CLASSIC_HIGH_SCORE_KEY);
    }
    public void DeleteFFHighScore()
    {
        PlayerPrefs.DeleteKey(Constants.FF_HIGH_SCORE_KEY);
    }
}
