using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightCamera : MonoBehaviour
{
    public PlayerController player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "Player")//change the camera for the boss fight
        {
            player.GetComponentInChildren<Camera>().orthographicSize = 100f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "Player")
        {
            player.GetComponentInChildren<Camera>().orthographicSize = 34.5f;
        }
    }
}
