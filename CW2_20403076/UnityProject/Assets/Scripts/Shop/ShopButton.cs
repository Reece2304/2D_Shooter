using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public GameObject ShopScreen1;
    public GameObject ShopScreen2;

    public void Next()
    {
        ShopScreen1.SetActive(false);
        ShopScreen2.SetActive(true);
    }
    public void Back()
    {
        ShopScreen2.SetActive(false);
        ShopScreen1.SetActive(true);
    }
}
