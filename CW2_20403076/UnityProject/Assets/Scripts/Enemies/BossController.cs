using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public int hp = 500;
    public int Maxhp = 500;
    public AudioSource audio;
    public AudioClip death;
    public AudioClip hurt;
    public Slider healthBar;
    public GameObject coinDrop;
    public GameObject healthDrop;
    public GameObject ammoDrop;
    void Start()
    {
    }
        
    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            healthBar.fillRect.GetComponent<Image>().enabled = false; //if the health is 0 then remove the red bar
            audio.PlayOneShot(death);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = null;
            Destroy(gameObject, death.length);
        }
        else
        {
            healthBar.fillRect.GetComponent<Image>().enabled = true;
            healthBar.value = (float)((float)hp / (float)Maxhp); //show the player's health as a percentage of their max hp
        }
    }

    public void damage(int dmg)
    {
        audio.PlayOneShot(hurt);
        hp -= dmg;
    }

    private void OnDestroy()
    {
        if (name != "Boss2(Clone)") //boss 2 spanws in minibosses to kill so rewards are not dropped
        {
            int chance = Random.Range(2, 4);
            for (int i = 0; i <= chance - 1; i++)
            {
                Vector3 pos = new Vector3(this.transform.position.x + i + 5, this.transform.position.y + i + 2, this.transform.position.z);
                Instantiate(healthDrop, pos, this.transform.rotation); //drop some health
            }
            for (int i = 0; i <= chance; i++) //drop lots of coins as the boss
            {
                Vector3 pos = new Vector3(this.transform.position.x + i * 3, this.transform.position.y + i, this.transform.position.z); //change the position of the dropped coins so that it's easier to see
                Instantiate(coinDrop, pos, this.transform.rotation); //drop some coins
            }
            for (int i = 0; i <= chance - 1; i++)
            {
                Vector3 pos = new Vector3(this.transform.position.x + i + 5, this.transform.position.y + i + 2, this.transform.position.z);
                Instantiate(ammoDrop, pos, this.transform.rotation); //drop some ammo
            }
        }
    }
}
