using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerScript : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(Constants.VOLUME))
        {
            PlayerPrefs.SetFloat(Constants.VOLUME, 0.5f);
        }
        Load();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(Constants.VOLUME);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat(Constants.VOLUME, volumeSlider.value);
    }
}
