using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameObject.FindObjectsOfType<EnemyController>().Length == 0 && GameObject.FindObjectsOfType<BossController>().Length == 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 25);
        }
    }

}
