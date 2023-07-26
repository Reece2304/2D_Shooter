using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BuyChar : MonoBehaviour
{
    public PlayerController player;
    // Start is called before the first frame update

    public TextMeshProUGUI char1Text;
    public TextMeshProUGUI char2Text;
    public TextMeshProUGUI char3Text;
    public bool error = false;
    public TextMeshProUGUI errorText;
    public void buy(int character) //pass character number when button is clicked
    {
        if (character == 0)
        {
            player.charSelected = 0;
            char1Text.text = "Selected";
            if (char2Text.text != "200")
            {
                char2Text.text = "select";
            }
            if (char3Text.text != "1000")
            {
                char3Text.text = "select";
            }
            error = false;
        }
        else if (character == 1)
        {
            if (player.char2Unlocked == true) //check if the character is already unlocked
            {
                player.charSelected = 1;
                char2Text.text = "Selected";
                char1Text.text = "select";
                if (char3Text.text != "1000")
                {
                    char3Text.text = "select";
                }
                error = false;
            }
            else
            {
                if (player.coinCount >= 200) //check if the player can purchase the character
                {
                    player.coinCount -= 200;
                    player.char2Unlocked = true;
                    player.charSelected = 1;
                    char2Text.text = "Selected";
                    char1Text.text = "Select";
                    if (char3Text.text != "1000")
                    {
                        char3Text.text = "select";
                    }
                    error = false;
                }
                else
                {
                    error = true;
                }
            }
        }
        else if (character == 2)
        {
            if (player.char3Unlocked == true)
            {
                player.charSelected = 2;
                char3Text.text = "Selected";
                char1Text.text = "select";
                if (char2Text.text != "200")
                {
                    char2Text.text = "select";
                }
                error = false;
            }
            else
            {
                if (player.coinCount >= 1000)
                {
                    player.coinCount -= 1000;
                    player.char3Unlocked = true;
                    player.charSelected = 2;
                    char3Text.text = "Selected";
                    char1Text.text = "select";
                    if (char2Text.text != "200")
                    {
                        char2Text.text = "select";
                    }
                    error = false;
                }
                else
                {
                    error = true;
                }
            }
        }
        if (error == true)
        {
            StartCoroutine(ShowError()); //show the error message for 1.5 seconds then remove it
            error = false;

        }
        else
        {
            player.changeSkin(character, false);// draw the player's new skin on screen with new updates values
        }
    }
    IEnumerator ShowError()
    {
        errorText.text = "Not Enough Coins";
        Time.timeScale = 1f;
        yield return StartCoroutine(RemoveError()); //show error and wait 1.5 seconds
        Time.timeScale = 0f;
        errorText.text = "";
    }
    IEnumerator RemoveError()
    {
        yield return new WaitForSeconds(1.5f);
    }
}
