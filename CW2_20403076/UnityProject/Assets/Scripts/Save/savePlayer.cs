using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class savePlayer
{
    //variables to save
    public int coins;
    public int health;
    public int shield;
    public int ammo;
    public int ultimate;
    public float[] playerPosition;
    public float volume;
    public int hpUp = 0;
    public int shieldUp = 0;
    public int speedUp = 0;
    public int ammoUp = 0;
    public int fireRateUp = 0;
    public int chargeUltUp = 0;
    public int coinRateUp = 0;
    public int damageUp = 0;
    public int charSelected = 0;
    public bool char2Unlocked = false;
    public bool char3Unlocked = false;
    public int runNumber = 0;
    public savePlayer(PlayerController player) //constructor to create a savePlayer instance
    {
        health = player.health;
        shield = player.shield;
        ammo = player.ammo;
        coins = player.coinCount;
        ultimate = player.ultimate;
        hpUp = player.hpUp;
        shieldUp = player.shieldUp;
        speedUp = player.speedUp;
        ammoUp = player.ammoUp;
        fireRateUp = player.fireRateUp;
        chargeUltUp = player.chargeUltUp;
        coinRateUp = player.coinRateUp;
        damageUp = player.damageUp;
        charSelected = player.charSelected;
        char2Unlocked = player.char2Unlocked;
        char3Unlocked = player.char3Unlocked;
        playerPosition = new float[3];
        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;
        playerPosition[2] = player.transform.position.z;
        runNumber = player.runNumber;
        volume = PlayerPrefs.GetFloat("volume");
    }
    public savePlayer()//create an empty player if there is no file found. To stop a bunch of errors
    {
        health = 100;
        shield = 0;
        ammo = 100;
        coins = 0;
        ultimate = 0;
        hpUp = 0;
        shieldUp = 0;
        speedUp =0;
        ammoUp = 0;
        fireRateUp = 0;
        chargeUltUp = 0;
        coinRateUp = 0;
        damageUp = 0;
        charSelected = 0;
        char2Unlocked = false;
        char3Unlocked = false;
        playerPosition = new float[3];
        playerPosition[0] = 1.2f;
        playerPosition[1] = 4f;
        playerPosition[2] = 0;
        runNumber = 0;
        volume = PlayerPrefs.GetFloat("volume");
    }
}
