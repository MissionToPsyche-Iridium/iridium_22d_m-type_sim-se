using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverPopup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject terrainPreview;

    public void OnPointerEnter(PointerEventData eventData)
    {
        terrainPreview.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        terrainPreview.SetActive(false);
    }
}