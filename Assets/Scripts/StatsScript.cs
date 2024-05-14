using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsScript : MonoBehaviour
{
    public TMP_Text classicHighScoreText;
    public TMP_Text ffHighScoreText;

    void OnEnable()
    {
        classicHighScoreText.SetText("Classic High Score: " + PlayerPrefs.GetInt(Constants.CLASSIC_HIGH_SCORE_KEY));
        ffHighScoreText.SetText("Free Flight High Score: " + PlayerPrefs.GetInt(Constants.FF_HIGH_SCORE_KEY));
    }
}
