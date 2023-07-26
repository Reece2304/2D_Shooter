using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BossDoor : MonoBehaviour
{
    bool inRange = false;
    public TextMeshProUGUI tooltip;
    public TextMeshProUGUI tooltip2;
    PlayerController player;
    private void Start()
    {
        tooltip.enabled = false;
        tooltip2.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.GetComponent<PlayerController>();
            if (player.hasKey)//check if the player has a key
            {
                tooltip.enabled = true;
                inRange = true;
            }
            else if(player.hasKey == false)
            {
                inRange = false;
                tooltip2.enabled = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") //remove the text from the screen when the player is not in sight
        {
            tooltip.enabled = false;
            tooltip2.enabled = false;
            inRange = false;
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E) && inRange == true) // if the player has a key and presses E then unlock the door
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 25);
            player.hasKey = false;//remove the player's key

        }
    }
}
