using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 70.0f;
    // Start is called before the first frame update
    private void Start()
    {
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        r.velocity = transform.right * speed;
    }
}
