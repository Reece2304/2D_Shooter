using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool optionsOpen = false;
    public GameObject optionsCanvas;
    public AudioSource hubMusic;
    public PlayerController player;
    public GameObject hud;
    void Start()
    {
        hubMusic.volume = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (optionsOpen == false && OpenShop.open == false && CharacterShop.open == false)
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        player.GetComponentInChildren<Camera>().GetComponent<AudioListener>().enabled = false; //otherwise there are two audio listeners
        hubMusic.volume = 0;
        hud.SetActive(false);
        optionsCanvas.SetActive(true); //show the options menu
        Time.timeScale = 0f;
        optionsOpen = true;
    }
    public void backButton()
    {
        player.GetComponentInChildren<Camera>().GetComponent<AudioListener>().enabled = true;
        hubMusic.volume = PlayerPrefs.GetFloat("volume");
        optionsCanvas.SetActive(false);
        Time.timeScale = 1f;
        hud.SetActive(true);
        optionsOpen = false;
    }

    public void saveAndQuit()
    {
        //call the save player function
        Save.savePlayer(player);
        //will quit the editor or the game.
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public AudioSource GetAudioSource()
    {
        return hubMusic;
    }
}
