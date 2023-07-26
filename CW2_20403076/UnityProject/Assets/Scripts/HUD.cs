using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HUD : MonoBehaviour
{
    public TextMeshProUGUI healthValue;
    public Slider healthBar;
    public TextMeshProUGUI shieldValue;
    public Slider shiledBar;
    public TextMeshProUGUI ultimateValue;
    public Slider ultimateBar;
    public TextMeshProUGUI ammoValue;
    public Image pistolBullet;
    public Image ak47Bullet;
    public Image RpgBullet;
    public Image key;
    public TextMeshProUGUI coinCount;
    private ParticleSystem particles;
    PlayerController player;
    Color color = new Color(0f, 1f, 0.03f);
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); //get the player 
        particles = GameObject.Find("Particles").GetComponent<ParticleSystem>();

    }
    void Update()
    {
        if (player.hasKey == true) //show the key in the hud if the player has picked one up
        {
            key.enabled = true;
        }
        else
        {
            key.enabled = false;
        }
        if (player.getHealth() <= 0)
        {
            healthBar.fillRect.GetComponent<Image>().enabled = false; //if the health is 0 then remove the red bar
        }
        else
        {
            healthBar.fillRect.GetComponent<Image>().enabled = true;
            healthBar.value = (float) ((float) player.getHealth() / (float) player.maxHealth); //show the player's health as a percentage of their max hp
        }
        if (player.shield == 0)
        {
            shiledBar.fillRect.GetComponent<Image>().enabled = false; //if the shield is 0 then remove the blue bar
            shieldValue.text = "Shield Depleted";
        }
        else
        {
            shiledBar.fillRect.GetComponent<Image>().enabled = true;
            shiledBar.value = (float)((float)player.shield / (float)player.maxShield); //show the player's shield as a percentage of their max shield
            shieldValue.text = player.shield.ToString();
        }
        if (player.ultimate == 0)
        {
            ultimateBar.fillRect.GetComponent<Image>().enabled = false; //if the shield is 0 then remove the blue bar
            ultimateValue.text = "0%";
        }
        else
        {
            ultimateBar.fillRect.GetComponent<Image>().enabled = true;
            ultimateBar.value = (float)((float)player.ultimate / 100.0f); //show the player's ultimate as a percentage
            if (player.ultimate == 100)
            {
                ultimateValue.text = "Ultimate Ready!";
                if(!particles.isPlaying)
                {
                    particles.Play();
                }
            }
            else
            {
                particles.Stop();
                ultimateBar.fillRect.GetComponent<Image>().color = color;
                ultimateValue.text = player.ultimate.ToString() + "%";
            }
        }
        ammoValue.text = player.ammo + "/" + player.maxAmmo; //update ammo text on screen
        if (player.charSelected == 0) //change the image on screen
        {
            pistolBullet.enabled = true;
            ak47Bullet.enabled = false;
            RpgBullet.enabled = false;
        }
        if (player.charSelected == 1)
        {
            ak47Bullet.enabled = true;
            pistolBullet.enabled = false;
            RpgBullet.enabled = false;
        }
        if (player.charSelected == 2)
        {
            RpgBullet.enabled = true;
            pistolBullet.enabled = false;
            ak47Bullet.enabled = false;
        }
        healthValue.text = player.getHealth().ToString();
        coinCount.text = player.coinCount.ToString();
        
    }
    
}
