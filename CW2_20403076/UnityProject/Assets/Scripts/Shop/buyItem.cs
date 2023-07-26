using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class buyItem : MonoBehaviour
{
    public PlayerController player;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI shieldText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI fireText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI dmgText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI ultText;
    public TextMeshProUGUI errorText;
    public TextMeshProUGUI hpTextDisplay;
    public TextMeshProUGUI shieldTextDisplay;
    public TextMeshProUGUI ammoTextDisplay;
    public TextMeshProUGUI fireTextDisplay;
    public TextMeshProUGUI coinTextDisplay;
    public TextMeshProUGUI dmgTextDisplay;
    public TextMeshProUGUI speedTextDisplay;
    public TextMeshProUGUI ultTextDisplay;
    public bool error = false;
    public void buy(string item) //when the button is clicked a text string of the clicked item is passed
    {
        int cost = 0;
        if (item == "hp")
        {
            cost = (player.getHpUp() * 100) + 10; //calculate the cost to upgrade
            if (player.coinCount >= cost)
            {
                player.coinCount -= cost; //if the player has enough coins then upgrade the chosen attribute
                player.hpUp += 1;
                player.updateMaxHp(); //update the players new max health after purchasing a health upgrade
                player.health = player.maxHealth;//fill their health up to max
                hpText.text = ((player.getHpUp() * 100) + 10).ToString(); //calculate the cost of the next upgrade and display that on the shop
                hpTextDisplay.text = "HP Upgrade " + (player.getHpUp() + 1).ToString();
                error = false;
            }
            else
            {
                error = true; //if the player doesn't have enough coins then display error message
            }
        }
        else if (item == "shield")
        {
            cost = (player.getshieldUp() * 150) + 15;
            if (player.coinCount >= cost)
            {
                player.coinCount -= cost;
                player.shieldUp += 1;
                player.updateMaxShield(); //update the players new max shield after purchasing a health upgrade
                player.shield = player.maxShield;//fill their shield up to max
                shieldText.text = ((player.getshieldUp() * 150) + 15).ToString(); //update the text elements to display to the user
                shieldTextDisplay.text = "Shield Upgrade " + (player.getshieldUp() + 1).ToString();
                error = false;
            }
            else
            {
                error = true;
            }
        }
        else if (item == "ammo")
        {
            cost = (player.getammoUp() * 100) + 10;
            if (player.coinCount >= cost)
            {
                player.coinCount -= cost;
                player.ammoUp += 1;
                player.updateMaxAmmo(); //update the players new max ammo after purchasing an ammo upgrade
                player.ammo = player.maxAmmo;//fill their ammo up to max
                ammoText.text = ((player.getammoUp() * 100) + 10).ToString();
                ammoTextDisplay.text = "Ammo Capacity" + (player.getammoUp() + 1).ToString();
                error = false;
            }
            else
            {
                error = true;
            }
        }
        else if (item == "fire")
        {
            cost = (player.getfireRateUp() * 250) + 25;
            if (player.coinCount >= cost)
            {
                player.coinCount -= cost;
                player.fireRateUp += 1;
                fireText.text = ((player.getfireRateUp() * 250) + 25).ToString();
                fireTextDisplay.text = "Fire Rate " + (player.getfireRateUp() + 1).ToString();
                error = false;
            }
            else
            {
                error = true;
            }
        }
        else if (item == "coin")
        {
            cost = (player.getcoinRateUp() * 300) + 30;
            if (player.coinCount >= cost)
            {
                player.coinCount -= cost;
                player.coinRateUp += 1;
                coinText.text = ((player.getcoinRateUp() * 300) + 30).ToString();
                coinTextDisplay.text = "Coin Rate " + (player.getcoinRateUp() + 1).ToString();
                error = false;
            }
            else
            {
                error = true;
            }
        }
        else if (item == "damage")
        {
            cost = (player.getdamageUp() * 500) + 50;
            if (player.coinCount >= cost)
            {
                player.coinCount -= cost;
                player.damageUp += 1;
                dmgText.text = ((player.getdamageUp() * 500) + 50).ToString();
                dmgTextDisplay.text = "Damage Upgrade " + (player.getdamageUp() + 1).ToString();
                error = false;
            }
            else
            {
                error = true;
            }
        }
        else if (item == "speed")
        {
            cost = (player.getspeedUp() * 200) + 50;
            if (player.coinCount >= cost)
            {
                player.coinCount -= cost;
                player.speedUp += 1;
                speedText.text = ((player.getspeedUp() * 200) + 50).ToString();
                speedTextDisplay.text = "Speed Upgrade " + (player.getspeedUp() + 1).ToString();
                error = false;
            }
            else
            {
                error = true;
            }
        }
        else if (item == "ult")
        {
            cost = (player.getChargeUltUp() * 800) + 150;
            if (player.coinCount >= cost)
            {
                player.coinCount -= cost;
                player.chargeUlt = 0;
                player.chargeUltUp += 1;
                ultText.text = ((player.getChargeUltUp() * 800) + 150).ToString();
                ultTextDisplay.text = "Ultimate Charge Speed " + (player.getChargeUltUp() + 1).ToString();
                error = false;
            }
            else
            {
                error = true;
            }
        }
        if (error == true)
        {
            StartCoroutine(ShowError()); //show the error message for 1.5 seconds then remove it
            error = false;
            
        }
    }
    IEnumerator ShowError()
    {
        errorText.text = "Not Enough Coins";
        Time.timeScale = 0.2f;
        yield return StartCoroutine(RemoveError());
        player.chargeUlt = 0;
        Time.timeScale = 0f;
        errorText.text = "";
    }
    IEnumerator RemoveError()
    {
        yield return new WaitForSeconds(0.15f);
    }
}
