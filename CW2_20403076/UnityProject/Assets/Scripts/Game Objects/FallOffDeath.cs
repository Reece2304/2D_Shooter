using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FallOffDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Player")
        {
            PlayerController player = collision.collider.GetComponent<PlayerController>();
            player.transform.position = new Vector3(1.2f, 4f, 0);
            //load the player into a random level
            player.ammo = player.maxAmmo;
            player.health = player.maxHealth;
            player.shield = player.maxShield;
            player.ultimate = 0;
            player.hasKey = false;
            Save.savePlayer(player);
            SceneManager.LoadScene(10);


        }

    }
}
