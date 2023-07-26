using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip explosion;
    GameObject player;
    BossController boss;
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
        if (collision.tag == "Enemy")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            PlayerController p1 = player.GetComponent<PlayerController>();
            p1.addUltimate(1);
            collision.GetComponent<EnemyController>().damage(75 * Mathf.FloorToInt((p1.getdamageUp() * 0.2f) + 1));
        }
        if (collision.tag == "Boss")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            PlayerController p1 = player.GetComponent<PlayerController>();
            p1.addUltimate(1);
            boss = collision.GetComponent<BossController>();
            boss.damage(75 * Mathf.FloorToInt((p1.getdamageUp() * 0.2f) + 1));
        }
    }
}
