using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject door;
    public GameObject Boss;
    public Transform bossPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y - 25);
        //spawn boss in here
        Instantiate(Boss, bossPos.position, bossPos.rotation);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
