using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    // Begin the game
    public void loadGame()
    {
        SceneManager.LoadScene(2);
    }

    public void loadOptions()
    {
        SceneManager.LoadScene(1);
    }

    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void quitGame()
    {
        //will quit the editor or the game.
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
