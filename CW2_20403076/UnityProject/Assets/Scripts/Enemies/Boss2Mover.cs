using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Mover : MonoBehaviour
{
    public Waypoint waypoint;
    float speed = 35f;
    public new AudioSource audio;
    public AudioClip hit;
    public GameObject SpikeBullet;
    int spawnSpike = 0;
    public Transform Boss1Spawn;
    public Transform Boss1Spawn2;
    public GameObject ChildBoss;
    // Start is called before the first frame update
    void Start()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint way in waypoints)
        {
            if (way.name == "BossWaypoint 1") //look for the boss waypoints
            {
                waypoint = way;
            }
        }
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("BossSpawn");
        foreach (GameObject spawn in spawns) //find the mini boss spawns
        {
            if (spawn.name == "Boss1Spawn")
            {
                Boss1Spawn = spawn.transform;
            }
            else
            {
                Boss1Spawn2 = spawn.transform;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            PlayerController player = collision.collider.GetComponent<PlayerController>();
            audio.PlayOneShot(hit);
            player.damage(40);

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

    private void FixedUpdate()
    {
        if (spawnSpike == 60)//spawn in spikes every second
        {
            spawnSpike = 0;
            Vector3 Spikepos = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
            Vector3 Spikepos2 = new Vector3(transform.position.x + 5, transform.position.y - 10, transform.position.z);
            Vector3 Spikepos3 = new Vector3(transform.position.x - 5, transform.position.y - 10, transform.position.z);
            Instantiate(SpikeBullet, Spikepos, transform.rotation);
            Instantiate(SpikeBullet, Spikepos2, transform.rotation);
            Instantiate(SpikeBullet, Spikepos3, transform.rotation);
        }
        spawnSpike += 1;
    }

    private void OnDestroy() //when destroyed create 2 clones as another challenge
    {
        Instantiate(ChildBoss, Boss1Spawn.position, transform.rotation);
        Instantiate(ChildBoss, Boss1Spawn2.position, transform.rotation);
    }
}
