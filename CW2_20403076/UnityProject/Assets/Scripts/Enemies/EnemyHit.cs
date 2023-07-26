using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    int isHitKey = Animator.StringToHash("hit");
    bool isHit = false;
    private void Update()
    {
        Animator a = GetComponent<Animator>();
        a.SetBool(isHitKey, isHit);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name == "bullet(Clone)" || collision.collider.gameObject.name == "rpg_rocket(Clone)" || collision.collider.gameObject.name == "Spy_Bullet(Clone)")
        {
            isHit = true;
        }
    }
    private void FixedUpdate()
    {
        isHit = false;
    }
}
