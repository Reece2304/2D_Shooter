using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpg_controller : MonoBehaviour
{
    public GameObject shot;
    public Transform shotTransform;
    float nextFire = 0.0f;
    public PlayerController player;
    public float fireRate = 2.5f;
    public AudioClip rpgSound;
    public AudioSource rpg;
    void Start()
    {
        fireRate = -((player.getfireRateUp() + 1) * 0.05f) + 2.5f; //get the amount of upgrades the user has and multiply it by 0.1 (fire rate increase per upgrade)
    }

    // Update is called once per frame
    void Update()
    {
        fireRate = -((player.getfireRateUp() + 1) * 0.05f) + 2.5f; //get the amount of upgrades the user has and multiply it by 0.1 (fire rate increase per upgrade)
        if (Input.GetButton("Fire1") && Time.time > nextFire && !CharacterShop.open && !OpenShop.open && player.ammo > 0)
        {
            player.ammo -= 1;
            nextFire = Time.time + fireRate;
            Instantiate(
            shot,
            shotTransform.position,
            shotTransform.rotation);
            rpg.PlayOneShot(rpgSound);
        }
    }
}
