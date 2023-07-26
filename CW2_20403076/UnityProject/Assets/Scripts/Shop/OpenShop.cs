using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OpenShop : MonoBehaviour
{
    public bool inRange = false;
    public GameObject canvas;
    public GameObject shop;
    public static bool open = false;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI coins2;
    public PlayerController player;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI shieldText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI fireText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI dmgText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI ultText;
    public TextMeshProUGUI hpTextDisplay;
    public TextMeshProUGUI shieldTextDisplay;
    public TextMeshProUGUI ammoTextDisplay;
    public TextMeshProUGUI fireTextDisplay;
    public TextMeshProUGUI coinTextDisplay;
    public TextMeshProUGUI dmgTextDisplay;
    public TextMeshProUGUI speedTextDisplay;
    public TextMeshProUGUI ultTextDisplay;
    // Start is called before the first frame update
    void Start()
    {
        coins.text = "     " + player.coinCount.ToString();
        coins2.text = "     " + player.coinCount.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        coins.text = "     " + player.coinCount.ToString();
        coins2.text = "     " + player.coinCount.ToString();
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
        shop.SetActive(true);
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

    public void populateText()
    {
        hpText.text = ((player.getHpUp() * 100) + 10).ToString();
        hpTextDisplay.text = "HP Upgrade " + (player.getHpUp() + 1).ToString();
        shieldTextDisplay.text = "Shield Upgrade " + (player.getshieldUp() + 1).ToString();
        ammoTextDisplay.text = "Ammo Capacity " + (player.getammoUp() + 1).ToString();
        fireTextDisplay.text = "Fire Rate " + (player.getfireRateUp() + 1).ToString();
        coinTextDisplay.text = "Coin Rate " + (player.getcoinRateUp() + 1).ToString();
        dmgTextDisplay.text = "Damage Upgrade " + (player.getdamageUp() + 1).ToString();
        speedTextDisplay.text = "speed Upgrade " + (player.getspeedUp() + 1).ToString();
        ultTextDisplay.text = "Ultimate Charge Speed " + (player.getChargeUltUp() + 1).ToString();
        shieldText.text = ((player.getshieldUp() * 150) + 15).ToString();
        ammoText.text = ((player.getammoUp() * 100) + 10).ToString();
        fireText.text = ((player.getfireRateUp() * 250) + 25).ToString();
        coinText.text = ((player.getcoinRateUp() * 300) + 30).ToString();
        dmgText.text = ((player.getdamageUp() * 500) + 50).ToString();
        speedText.text = ((player.getspeedUp() * 200) + 50).ToString();
        ultText.text = ((player.getChargeUltUp() * 800) + 150).ToString();
    }
}
