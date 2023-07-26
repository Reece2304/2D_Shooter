using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour
{
    public new AudioSource audio;
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
            if (player.health != player.maxHealth)
            {
                if (player.health + 5 >= player.maxHealth) //stop health going above maximum value
                {
                    player.health = player.maxHealth;
                }
                else
                {
                    player.health += 5;
                }
            }
            audio.PlayOneShot(pickup);
            GetComponent<BoxCollider2D>().enabled = false; //sound takes a long time to play, prevent the player from constantly gaining health
            GetComponent<SpriteRenderer>().sprite = null;
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
