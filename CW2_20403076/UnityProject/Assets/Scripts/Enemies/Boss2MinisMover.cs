using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2MinisMover : MonoBehaviour
{
    public Waypoint waypoint;
    float speed = 35f;
    public new AudioSource audio;
    public AudioClip hit;
    // Start is called before the first frame update
    void Start()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint way in waypoints)
        {
            if (way.name == "MiniBossWaypoint 1")
            {
                waypoint = way;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            PlayerController player = collision.collider.GetComponent<PlayerController>();
            audio.PlayOneShot(hit);
            player.damage(20);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(waypoint.transform.position, transform.position) < 1)
        {
            Waypoint nextWaypoint = waypoint.nextWaypoint;
            waypoint = nextWaypoint;

        }
        transform.position = Vector3.MoveTowards(transform.position, waypoint.transform.position, Time.deltaTime * speed);
    }
}
