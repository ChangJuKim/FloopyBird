using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeFlightScript : MonoBehaviour
{
    [SerializeField] Toggle freeFlightToggle;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(Constants.IS_FF_KEY))
        {
            PlayerPrefs.SetString(Constants.IS_FF_KEY, false.ToString());
        }
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        Save();
    }

    private void Load()
    {
        freeFlightToggle.isOn = bool.Parse(PlayerPrefs.GetString(Constants.IS_FF_KEY));
    }

    private void Save()
    {
        PlayerPrefs.SetString(Constants.IS_FF_KEY, freeFlightToggle.isOn.ToString());
    }
}
