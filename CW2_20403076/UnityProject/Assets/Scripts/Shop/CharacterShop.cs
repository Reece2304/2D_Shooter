using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CharacterShop : MonoBehaviour
{
    public bool inRange = false;
    public GameObject canvas;
    public GameObject shop;
    public static bool open = false;
    public TextMeshProUGUI coins;
    public PlayerController player;
    public TextMeshProUGUI char1Text;
    public TextMeshProUGUI char2Text;
    public TextMeshProUGUI char3Text;
    // Start is called before the first frame update
    void Start()
    {
        coins.text = "     " + player.coinCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = "     " + player.coinCount.ToString();
        if (inRange) //check if the player is in range of the shop
        {
            canvas.SetActive(true); //display the text telling the player how to open the shop
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (open)
                {
                    //if the shop is open the player can leave by pressing E
                    CloseShop();
                }
                else
                {
                    ShopOpen();
                }
            }
        }
        else
        {
            canvas.SetActive(false); //if the player is not in range hide all the elements
            shop.SetActive(false);
            open = false;
        }

    }

    private void ShopOpen()
    {
        shop.SetActive(true); //display the canvas to the user
        populateText();
        Time.timeScale = 0f;
        open = true;
    }

    private void CloseShop()
    {
        shop.SetActive(false);
        Time.timeScale = 1f;
        open = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inRange = false;
    }

    public void populateText() //check what character the player has unlocked and is currently playing.
    {
        if (player.charSelected == 0)
        {
            char1Text.text = "selected";
        }
        if (player.charSelected == 1)
        {
            char2Text.text = "selected";
        }
        if (player.charSelected == 2)
        {
            char3Text.text = "selected";
        }
        if (player.charSelected != 0)
        {
            char1Text.text = "select";
        }
        if (player.char2Unlocked == true && (player.charSelected != 1))
        {
            char2Text.text = "select";
        }
        if (player.char2Unlocked == false)
        {
            char2Text.text = "200";
        }
        if (player.charSelected == 1)
        {
            char2Text.text = "selected";
        }
        if (player.char3Unlocked == true && !(player.charSelected == 2))
        {
            char3Text.text = "select";
        }
        if (player.char3Unlocked == false)
        {
            char3Text.text = "1000";
        }
    }
}
