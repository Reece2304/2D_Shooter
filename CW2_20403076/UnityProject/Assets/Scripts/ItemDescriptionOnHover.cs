using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDescriptionOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public GameObject descriptionText;
    void Start()
    {
        descriptionText.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionText.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        descriptionText.SetActive(false);
    }
}
