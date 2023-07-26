  
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private Transform leftPos;
    private Transform rightPos;
    public Transform enemyPos;
    public float speed;
    private Vector3 scale;
    private bool movingLeft;
    private float Duration;
    private float idle;


    private void Start()
    {
        scale = enemyPos.localScale;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Feet"); //find the left and right patrol points
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("enemySpawn"); //find the left and right patrol points

        if (name == "BeeEnemy2(Clone)")
        {
            foreach (GameObject obj in spawns)
            {
                if (obj.name == "Right_Side (1)")
                {

                    rightPos = obj.transform;
                }
                else
                {
                    leftPos = obj.transform;
                }
            }
        }
        else
        {
            foreach (GameObject obj in objs)
            {
                if (obj.name == "Right_Side")
                {

                    rightPos = obj.transform;
                }
                else
                {
                    leftPos = obj.transform;
                }
            }

        }

        leftPos.position = new Vector3(leftPos.position.x, enemyPos.position.y, enemyPos.position.z);
        rightPos.position = new Vector3(rightPos.position.x, enemyPos.position.y, enemyPos.position.z);
    }

    private void Update()
    {
        if (movingLeft)//check if the enemyPos is moving left
        {
            if (enemyPos.position.x >= leftPos.position.x)//if the enemy has moved past the left point change direction
                ChangeDirection(-1);
            else
                flipSprite();
        }
        else
        {
            if (enemyPos.position.x <= rightPos.position.x)
            {
                ChangeDirection(1);
            }
            else
            {
                flipSprite();
            }
        }
    }

    private void flipSprite()
    {
        idle += Time.deltaTime;

        if (idle > Duration)
        {
            movingLeft = !movingLeft;
        }
            
    }

    private void ChangeDirection(int direction)
    {
        idle = 0;
        enemyPos.localScale = new Vector3(scale.x * direction * -1, scale.y, scale.z); //change the direction the enemy is facing
        enemyPos.position = new Vector3(enemyPos.position.x + Time.deltaTime * direction * speed, enemyPos.position.y, enemyPos.position.z); //move the enemy in that direction
    }
}