using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeEnemy : MonoBehaviour
{
    public float attackReady;
    private float Timer = Mathf.Infinity;
    public new CapsuleCollider2D collider;
    public LayerMask layer;
    public GameObject beeAttack;
    int isAttKey = Animator.StringToHash("attacking");
    bool isAtt = false;
    public new AudioSource audio;
    public AudioClip StingerFire;
    // Update is called once per frame
    void Update()
    {
        Animator a = GetComponent<Animator>();
        a.SetBool(isAttKey, isAtt);
        Timer += Time.deltaTime;
        if (canSeePlayer())
        {
            if (Timer >= attackReady) //attack every number of seconds
            {
                Timer = 0;
                isAtt = true;
                StartCoroutine(StopAnimation());

            }
        }
    }
    private bool canSeePlayer()
    {
        RaycastHit2D see = Physics2D.BoxCast(new Vector3(collider.bounds.center.x, collider.bounds.center.y - 35) + -transform.up * 3 * (transform.localScale.x / 25), new Vector3(collider.bounds.size.x * 1.5f, collider.bounds.size.y * 10), 0, Vector2.left, 0, layer); //attack 10 units infront
        return see.collider != null;
    }

    private void shootStinger()
    {
        Instantiate(beeAttack, collider.bounds.center + -transform.up * 6 * (transform.localScale.x / 25), this.transform.rotation);
    }

    private void OnDrawGizmos() //if the player is underneath the bee it should be able to see it
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(collider.bounds.center.x, collider.bounds.center.y -35) + -transform.up * 3 * (transform.localScale.x / 25), new Vector3(collider.bounds.size.x * 1.5f,collider.bounds.size.y * 10));//draw it in unity so that it's visible
    }
    IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        shootStinger(); //the attack
        audio.PlayOneShot(StingerFire);
        isAtt = false;
    }
}
