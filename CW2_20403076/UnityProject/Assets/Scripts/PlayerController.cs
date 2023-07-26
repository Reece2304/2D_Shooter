using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    bool canJump = true;
    int groundMask = 1 << 8; // this is a “bitshift”
                             // Update is called once per frame
    bool isIdle;
    bool isLeft;
    int isIdleKey = Animator.StringToHash("isIdle");
    bool isJump;
    int isJumpKey = Animator.StringToHash("isJump");

    int idleTime = 0;
    int idleTimeKey = Animator.StringToHash("idleTime");

    public int coinCount = 0;
    public int health = 100;
    public int maxHealth = 100;
    public int shield = 0;
    public int maxShield = 0;
    public int ammo = 100;
    public int maxAmmo = 100;
    public int ultimate = 0;
    public int hpUp = 0;
    public int chargeUltUp = 0;
    public int speedUp = 0;
    public int shieldUp = 0;
    public int ammoUp = 0;
    public int fireRateUp = 0;
    public int coinRateUp = 0;
    public int damageUp = 0;
    public int runNumber = 0;
    public int chargeUlt = 0;
    public int charSelected = 0;
    public bool char2Unlocked = false;
    public bool char3Unlocked = false;
    public RuntimeAnimatorController char1Anim;
    public RuntimeAnimatorController char2Anim;
    public RuntimeAnimatorController char3Anim;
    public GameObject pistol;
    public GameObject ak47;
    public GameObject rpg;
    public bool hasKey = false;
    public GameObject explosion;
    public AudioSource audio;
    public AudioClip death;
    //Load the players last point into the game
    private void Start()
    {
        savePlayer data = Save.loadPlayer();//load the players stats into the game.
        coinCount = data.coins;
        health = data.health;
        shield = data.shield;
        hpUp = data.hpUp;
        shieldUp = data.shieldUp;
        speedUp = data.speedUp;
        ammoUp = data.ammoUp;
        fireRateUp = data.fireRateUp;
        coinRateUp = data.coinRateUp;
        damageUp = data.damageUp;
        chargeUltUp = data.chargeUltUp;
        charSelected = data.charSelected;
        char2Unlocked = data.char2Unlocked;
        char3Unlocked = data.char3Unlocked;
        runNumber = data.runNumber;
        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];
        position.z = data.playerPosition[2];
        transform.position = position;
        AudioListener.volume = data.volume;
        ammo = data.ammo;
        ultimate = data.ultimate;
        maxShield = shieldUp * 25;
        changeSkin(charSelected, true);
    }
    private void Update()
    {
        Animator a = GetComponent<Animator>();
        a.SetBool(isIdleKey, isIdle);
        a.SetBool(isJumpKey, isJump);
        a.SetInteger(idleTimeKey, idleTime);
        SpriteRenderer r = GetComponent<SpriteRenderer>();
        r.flipX = isLeft;
        if(health <= 0)
        {
            //Remove all the clone objects in the scene
            GameObject[] clones = GameObject.FindGameObjectsWithTag("clone");
            foreach (GameObject clone in clones)
            {
                Destroy(clone);
            }
            //Save the player's new coin balance and reset their health. Then load a death screen
            health = maxHealth;
            shield = maxShield;
            ammo = maxAmmo;
            this.transform.position = new Vector3(1.2f, 4f, 0);
            ultimate = 0;
            hasKey = false;
            Save.savePlayer(this);
            SceneManager.LoadScene(10);
        }
    }
    void FixedUpdate()
    {
        // the new velocity to apply to the character
        Vector2 physicsVelocity = Vector2.zero;
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        // move to the left
        isIdle = true;
        if(isIdle)
        {
            idleTime += 1;
        }
        if (idleTime >= 300)
        {
            idleTime = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            physicsVelocity.x -= 25 + (speedUp * 2);
            isLeft = true;
            isIdle = false;
            idleTime = 0;
            if (canJump)
            {
                isJump = false;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (canJump)
            {
                isJump = false;
            }
            physicsVelocity.x += 25 + (speedUp * 2);
            isLeft = false;
            isIdle = false;
            idleTime = 0;
        }
        // implement moving to the right for the D key
        // this allows the player to jump, but only if canJump is true
        if (Input.GetKey(KeyCode.W))
        {
            if (canJump)
            {
                // we're setting the absolute velocity here
                // but we still want to carry on moving left
                // or right. So include the current horizontal
                // velocity
                r.velocity = new Vector2(physicsVelocity.x, 38 + (speedUp * 3));
                canJump = false;
                isJump = true;
            }
        }
        // Test the ground immediately below the Player
        // and if it tagged as a Ground layer, then we allow the
        // Player to jump again. The capsule collider is 4.8 units
        // high, so 2.5 units “down” from its centre will be just
        // touching the floor when we are on the ground.
        if (Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y),-Vector2.up, 5.0f, groundMask))
        {
            canJump = true;
            isJump = false;
        }
        if (Input.GetKey(KeyCode.Space) && ultimate == 100) //player uses their ultimate ability and its fully charged
        {
            if (charSelected == 0)
            {
                health = maxHealth;
                shield = maxShield;
            }
            else if (charSelected == 1)
            {
                explode(); 
            }
            else if (charSelected == 2)
            {
                ammo = maxAmmo;
            }
            ultimate = 0;
        }
        if (ultimate < 100)
        {
            chargeUlt += 1;
            if (chargeUlt == 125 - (chargeUltUp * 8))
            {
                chargeUlt = 0;
                ultimate += 1;
            }
        }
        // apply the updated velocity to the rigid body
        r.velocity = new Vector2(physicsVelocity.x,
        r.velocity.y);
    }
    public int getGold()
    {
        return coinCount;
    }
    public void addGold(int gold)
    {
        coinCount += gold;
    }
    public void addHealth(int hp)
    {
        health += hp;
    }
    public int getHealth()
    {
        return health;
    }
    public int getHpUp()
    {
        return hpUp;
    }
    public int getshieldUp()
    {
        return shieldUp;
    }
    public int getammoUp()
    {
        return ammoUp;
    }
    public int getfireRateUp()
    {
        return fireRateUp;

    }
    public int getcoinRateUp()
    {
        return coinRateUp;

    }
    public int getdamageUp()
    {
        return damageUp;

    }
    public int getspeedUp()
    {
        return speedUp;

    }
    public int getChargeUltUp()
    {
        return chargeUltUp;
    }
    public void updateMaxHp()
    {
        maxHealth += 25;
    }
    public void updateMaxShield()
    {
        maxShield += 25;
    }
    public void updateMaxAmmo()
    {
        if (charSelected == 0)
        {
            maxAmmo += 25;
        }
        else if (charSelected == 1)
        {
            maxAmmo += 50;
        }
        else if (charSelected == 2)
        {
            maxAmmo += 10;
        }
        
    }
    public void addUltimate(int ultimateAdd)
    {
        if (ultimate + ultimateAdd < 100)
        {
            ultimate += ultimateAdd;
        }
        if (ultimate + ultimateAdd >= 100)
        {
            ultimate = 100;
            chargeUlt = 0;
        }
    }
    public void damage(int damage)
    {
        if (shield >= damage) //take damage from the shield first
        {
            shield -= damage;
        }
        else if (shield > 0)
        {
            health -= (damage - shield);
            shield = 0;
        }
        else
        {
            health -= damage;
        }
    }
    public bool getHasKey()
    {
        return hasKey;
    }
    public void setHasKey(bool key)
    {
        hasKey = key;
    }
    public void explode()
    {
        Instantiate(explosion, this.transform.position, this.transform.rotation);
    }
    public void changeSkin(int character, bool loadedIn) //change the player's skin and attributes affiliated with said skin.
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Animator an = GetComponent<Animator>();
        if (character == 0)
        {
            charSelected = 0;
            an.runtimeAnimatorController = char1Anim;
            sr.drawMode = SpriteDrawMode.Simple; //the other characters have to be drawn in a different way otherwise they're too small

            maxHealth = 100 + ((hpUp) * 25); //change the user's health
            maxAmmo = 100 + (ammoUp * 25);
            if (!loadedIn)
            {
                ammo = maxAmmo; //if the user has changed their char (i.e in the hub) then give them max values
                health = 100 + ((hpUp) * 25); //to stop players save and quit in mid fight, load back in and get max health back
            }
            pistol.SetActive(true); //enable and disable the guns and correlated scripts to the character
            ak47.SetActive(false);
            rpg.SetActive(false);
            GetComponent<rpg_controller>().enabled = false;
            GetComponent<gun_controller>().enabled = true;
            GetComponent<ak47_controller>().enabled = false;
        }
        if (character == 1)
        {
            charSelected = 1;
            an.runtimeAnimatorController = char2Anim;
            sr.drawMode = SpriteDrawMode.Sliced;
            maxHealth = 150 + ((hpUp) * 25);
            maxAmmo = 300 + (ammoUp * 50);
            if (!loadedIn)
            {
                ammo = maxAmmo;
                health = 150 + ((hpUp) * 25);
            }
            pistol.SetActive(false);
            ak47.SetActive(true);
            rpg.SetActive(false);
            GetComponent<rpg_controller>().enabled = false;
            GetComponent<ak47_controller>().enabled = true;
            GetComponent<gun_controller>().enabled = false;
        }
        if (character == 2)
        {
            charSelected = 2;
            an.runtimeAnimatorController = char3Anim;
            sr.drawMode = SpriteDrawMode.Sliced;
            maxHealth = 500 + ((hpUp) * 25);
            maxAmmo = 42 + (ammoUp * 10);
            if (!loadedIn)
            {
                ammo = maxAmmo;
                health = 500 + ((hpUp) * 25);
            }
            pistol.SetActive(false);
            ak47.SetActive(false);
            rpg.SetActive(true);
            GetComponent<rpg_controller>().enabled = true;
            GetComponent<ak47_controller>().enabled = false;
            GetComponent<gun_controller>().enabled = false;
        }
        PlayerPrefs.SetInt("CharacterSelected", character);
    }
}
