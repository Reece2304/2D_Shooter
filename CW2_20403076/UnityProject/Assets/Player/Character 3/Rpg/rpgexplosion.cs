using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpgexplosion : MonoBehaviour
{
    public GameObject explosion;
    public Transform bullet;
    //public AudioSource rpg;
    //public AudioClip explosionSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject clone = Instantiate(
                    explosion,
                    bullet.position,
                    bullet.rotation);
        //rpg.PlayOneShot(explosionSound);
        Object.Destroy(gameObject);
        
    }
}
