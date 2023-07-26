using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip pickup;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().setHasKey(true);
            audio.PlayOneShot(pickup,5);
            Destroy(gameObject, pickup.length);//wait until the sound finishes to destroy
        }
    }
}
