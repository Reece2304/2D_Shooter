using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ak47_controller : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject shot;
    public Transform shotTransform;
    float nextFire = 0.0f;
    public PlayerController player;
    public float fireRate = 1.5f;
    public AudioClip ak47Sound;
    public AudioSource ak47;
    void Start()
    {
        fireRate = -((player.getfireRateUp() + 1) * 0.05f) + 0.8f; //get the amount of upgrades the user has and multiply it by 0.1 (fire rate increase per upgrade)
    }

    // Update is called once per frame
    void Update()
    {
        fireRate = -((player.getfireRateUp() + 1) * 0.05f) + 0.8f; //get the amount of upgrades the user has and multiply it by 0.1 (fire rate increase per upgrade)
        if (Input.GetButton("Fire1") && Time.time > nextFire && !CharacterShop.open && !OpenShop.open && player.ammo > 0)
        {
            player.ammo -= 1;
            nextFire = Time.time + fireRate;
            Instantiate(
            shot,
            shotTransform.position,
            shotTransform.rotation);
            ak47.PlayOneShot(ak47Sound);
        }
    }
}
