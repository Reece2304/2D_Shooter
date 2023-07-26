using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip pickup;
    private void Start()
    {
        Destroy(gameObject, 15);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player.ammo != player.maxAmmo)//when the ammo is picked up add ammo to the player depending on the gun
            {
                if (player.charSelected == 0)
                {
                    if (player.ammo + 5 >= player.maxAmmo) //stop ammo going above maximum value
                    {
                        player.ammo = player.maxAmmo;
                    }
                    else
                    {
                        player.ammo += 5;
                    }
                }
                else if (player.charSelected == 1)
                {
                    if (player.ammo + 10 >= player.maxAmmo) //stop ammo going above maximum value
                    {
                        player.ammo = player.maxAmmo;
                    }
                    else
                    {
                        player.ammo += 10;
                    }
                }
                else if (player.charSelected == 2)
                {
                    if (player.ammo + 2 >= player.maxAmmo) //stop ammo going above maximum value
                    {
                        player.ammo = player.maxAmmo;
                    }
                    else
                    {
                        player.ammo += 2;
                    }
                }
            }

            audio.PlayOneShot(pickup);
            Destroy(gameObject, pickup.length);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
