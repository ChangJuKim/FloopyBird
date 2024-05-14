using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsScript : MonoBehaviour
{
    public TMP_Text highScoreText;

    void OnEnable()
    {
        highScoreText.SetText("High Score: " + PlayerPrefs.GetInt(Constants.HIGH_SCORE_KEY));
    }
}
