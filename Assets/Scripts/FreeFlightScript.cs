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
        if (!PlayerPrefs.HasKey(Constants.FREE_FLIGHT_KEY))
        {
            PlayerPrefs.SetString(Constants.FREE_FLIGHT_KEY, false.ToString());
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
        freeFlightToggle.isOn = bool.Parse(PlayerPrefs.GetString(Constants.FREE_FLIGHT_KEY));
    }

    private void Save()
    {
        PlayerPrefs.SetString(Constants.FREE_FLIGHT_KEY, freeFlightToggle.isOn.ToString());
    }
}
