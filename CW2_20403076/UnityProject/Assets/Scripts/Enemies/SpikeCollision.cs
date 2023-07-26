using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollision : MonoBehaviour
{
    public new AudioSource audio;
    public AudioClip spike;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<PlayerController>().damage(5);
            audio.PlayOneShot(spike);
        }
        GetComponent<EdgeCollider2D>().enabled = false;
        Destroy(gameObject,0.5f);
    }
}
