using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDoor : MonoBehaviour
{
    public Transform[] transforms = new Transform[5];
    public GameObject Enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 25);
            GetComponent<CircleCollider2D>().enabled = false;
            for (int i = 0; i <= transforms.Length-1; i++) //loop through the enemy spawn points and spawn them in
            {
                if (transforms[i] != null)
                {
                    Instantiate(Enemy, transforms[i].position, transforms[i].rotation);
                }
            }
        }
    }
}
