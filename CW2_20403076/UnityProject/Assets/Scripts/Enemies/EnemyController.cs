using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public int hp = 100;
    public int Maxhp = 100;
    public new AudioSource audio;
    public AudioClip death;
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
            Destroy(gameObject);
        }
        else
        {
            healthBar.fillRect.GetComponent<Image>().enabled = true;
            healthBar.value = (float)((float)hp/ (float)Maxhp); //show the player's health as a percentage of their max hp
        }
    }

   public void damage(int dmg)
    {
        audio.PlayOneShot(death);
        hp -= dmg;
    }

    private void OnDestroy()
    {
        int chance = Random.Range(1, 5);

        if (name == "BeeEnemy (Clone)") //bees are worth more to kill
        {
            chance = Random.Range(2, 5);
        }
        if (chance >= 4) //random chance to get some health every kill
        {
            Vector3 pos = new Vector3(this.transform.position.x + 5, this.transform.position.y + 2, this.transform.position.z);
            Instantiate(healthDrop, pos, this.transform.rotation); //drop some health
        }
        for (int i = 0; i <= chance-1; i++)
        {
            Vector3 pos = new Vector3(this.transform.position.x + i * 3, this.transform.position.y + i, this.transform.position.z); //change the position of the dropped coins so that it's easier to see
            Instantiate(coinDrop, pos, this.transform.rotation); //drop some coins
        }
        if (chance >= 3) //random chance to get some ammo every kill
        {
            Vector3 pos = new Vector3(this.transform.position.x + 5, this.transform.position.y  + 2, this.transform.position.z);
            Instantiate(ammoDrop, pos, this.transform.rotation); //drop some ammo
        }
    }
}
