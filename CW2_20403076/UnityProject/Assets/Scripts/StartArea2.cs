using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartArea2: MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.collider.GetComponent<PlayerController>();
        if (collision.collider.tag == "Player")
        {
                player.transform.position = new Vector3(0, 0, 0);
                //load the player into a random level
                int level = Random.Range(7, 10);
                Save.savePlayer(player);
                SceneManager.LoadScene(level);


        }

    }
}