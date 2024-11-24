using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystem;

public class HoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject HoverObject;

    public void OnPointerEnter(PointerEventData eventData) {
        HoverObject.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        HoverObject.setActive(false);
    }
}
