using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;
    public TextMeshProUGUI volumeLevel;
    // Start is called before the first frame update
    void Start()
    {
        //Check if there is a volume preference
        if (PlayerPrefs.HasKey("volume"))
        {
            load();
        }
        else
        {
            //otherwise set the volume % to 100
            PlayerPrefs.SetFloat("volume", 1);
            volumeLevel.text = "100";
        }
    }

    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        //Debug.Log(volumeSlider.value);
        volumeLevel.text = (Math.Round(volumeSlider.value, 2) * 100).ToString(); //Display the change to the user
        save();
    }

    private void load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
        volumeLevel.text = (Math.Round(volumeSlider.value, 2) * 100).ToString();
    }
    private void save()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value); //Save the value to the player prefs so the user doesn't have to change every time they load

    }
}
