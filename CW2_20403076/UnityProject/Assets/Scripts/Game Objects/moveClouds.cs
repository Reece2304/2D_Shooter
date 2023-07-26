using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class moveClouds : MonoBehaviour
{
    // Start is called before the first frame update

    Vector2 originalPosition;
    void Start()
    {
        originalPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 250f)
        {
            transform.position = new Vector2(-250f,originalPosition.y);
        }
        else
        {
            transform.Translate(6f * Time.deltaTime, 0, 0);
            //Debug.Log(transform.position.x);
        }

    }
}
