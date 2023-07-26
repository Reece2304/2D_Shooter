using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeStinger : MonoBehaviour
{
    public float speed = 70.0f;
    public new AudioSource audio;
    public AudioClip StingerHit;
    // Start is called before the first frame update
    private void Start()
    {
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        r.velocity = -transform.up * speed;
        Destroy(gameObject, 5);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<PlayerController>().damage(10);
            GetComponent<CapsuleCollider2D>().enabled = false;
            audio.PlayOneShot(StingerHit);
        }
        Destroy(gameObject, StingerHit.length);
    }
}
