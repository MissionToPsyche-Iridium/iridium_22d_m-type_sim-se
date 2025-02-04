using UnityEngine;

public class HoverPopupController : MonoBehaviour
{
    public GameObject hoverPopup; 

    private void OnMouseEnter()
    {
        if (hoverPopup != null)
        {
            hoverPopup.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (hoverPopup != null)
        {
            hoverPopup.SetActive(false);
        }
    }
}
