using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkCollision : MonoBehaviour
{
    EnemyController enemy;
    BossController boss;
    GameObject player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Object.Destroy(gameObject);
        if (collision.collider.tag == "Enemy")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            PlayerController p1 = player.GetComponent<PlayerController>();

            p1.addUltimate(5);
            enemy = collision.collider.GetComponent<EnemyController>();
            enemy.damage(10 * Mathf.FloorToInt((p1.getdamageUp() * 0.2f) + 1));
        }
        if (collision.collider.tag == "Boss")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            PlayerController p1 = player.GetComponent<PlayerController>();
            p1.addUltimate(5);
            boss = collision.collider.GetComponent<BossController>();
            boss.damage(10 * Mathf.FloorToInt((p1.getdamageUp() * 0.2f) + 1));
        }

    }
}