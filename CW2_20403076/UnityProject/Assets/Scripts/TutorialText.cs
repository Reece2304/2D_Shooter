using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TutorialText : MonoBehaviour
{
    public GameObject tutorial;

    private void Start()
    {
        tutorial.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        tutorial.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        tutorial.SetActive(false);
    }
}
