using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeEnemies : MonoBehaviour
{

    public float attackReady;
    private float Timer = Mathf.Infinity;
    public new BoxCollider2D collider;
    public LayerMask layer;
    public GameObject explosion;
    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (canSeePlayer())
        {
            if (Timer >= attackReady) //attack every number of seconds
            {
                Timer = 0;
                explode(); //the attack
            }
        }
    }
    private bool canSeePlayer()
    {
        RaycastHit2D see = Physics2D.BoxCast(collider.bounds.center + -transform.right*10 * (transform.localScale.x/25), collider.bounds.size, 0, Vector2.left,0, layer); //attack 10 units infront
        return see.collider != null;
    }

    private void explode()
    {
        Instantiate(explosion, collider.bounds.center + -transform.right * 10 * (transform.localScale.x / 25), this.transform.rotation);
    }

    private void onDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(collider.bounds.center + -transform.right * 10 * (transform.localScale.x / 25), collider.bounds.size);
    }
    
}
