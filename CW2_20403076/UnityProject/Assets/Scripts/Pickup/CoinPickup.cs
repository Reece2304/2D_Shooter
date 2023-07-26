using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public new AudioSource audio;
    public AudioClip pickup;

    private void Start()
    {
        Destroy(gameObject, 15); //15 seconds to pick up the object before it's destroyed
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().coinCount += 35; //when the coin is picked up add coins to the player
            audio.PlayOneShot(pickup);
            GetComponent<SpriteRenderer>().sprite = null;
            Destroy(gameObject, pickup.length);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            GetComponent<CapsuleCollider2D>().enabled = false; //stop the player from picking the same object up more than once
            GetComponent<SpriteRenderer>().sprite = null;
        }    
    }
}
