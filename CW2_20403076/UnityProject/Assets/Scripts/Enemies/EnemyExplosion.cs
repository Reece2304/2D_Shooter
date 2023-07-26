using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip explosion;
    GameObject player;
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(explosion);
        StartCoroutine(removeExplosion());
    }

    IEnumerator removeExplosion()
    {
        yield return new WaitForSeconds(1);
        Object.Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            PlayerController p1 = player.GetComponent<PlayerController>();
            p1.damage(10);
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
