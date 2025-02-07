using UnityEngine;

public class HoverPopupController : MonoBehaviour
{
    public GameObject archHoverPopup; 

    private void OnMouseEnter()
    {
        if (archHoverPopup != null)
        {
            archHoverPopup.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (archHoverPopup != null)
        {
            archHoverPopup.SetActive(false);
        }
    }
}
