using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class startGame : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            PlayerController player = collision.collider.GetComponent<PlayerController>();
            if (player.runNumber == 0)
            {
                player.runNumber += 1;
                player.transform.position = new Vector3(-181,-11,0);
                player.ammo = player.maxAmmo;
                player.health = player.maxHealth;
                player.shield = player.maxShield;
                player.ultimate = 0;
                Save.savePlayer(player);
                SceneManager.LoadScene(6); //run the tutorial level if the player hasn't played before.
            }
            else
            {
                player.transform.position = new Vector3(0, 0, 0);
                //load the player into a random level
                int level = Random.Range(3, 6);
                player.ammo = player.maxAmmo;
                player.health = player.maxHealth;
                player.shield = player.maxShield;
                player.ultimate = 0;
                Save.savePlayer(player);
                SceneManager.LoadScene(level);
            }    

        }

    }
}
