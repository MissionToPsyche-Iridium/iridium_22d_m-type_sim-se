using UnityEngine;

public class ClawHoverPopup : MonoBehaviour
{
    public GameObject clawHoverPopup; 

    private void OnMouseEnter()
    {
        if (clawHoverPopup != null)
        {
            clawHoverPopup.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (clawHoverPopup != null)
        {
            clawHoverPopup.SetActive(false);
        }
    }
}