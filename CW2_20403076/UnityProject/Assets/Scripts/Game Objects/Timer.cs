using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimeText;
    float StartTime = 360;
    private void Update()
    {
        StartTime -= Time.deltaTime;
        TimeText.text = Mathf.FloorToInt((StartTime/60)).ToString() + ":" + Mathf.FloorToInt((StartTime % 60)).ToString(); //display the time in minutes and seconds
        if (StartTime <= 0)
        {
            SceneManager.LoadScene(12); //player has run out of time so load a different scene
        }
    }

}
