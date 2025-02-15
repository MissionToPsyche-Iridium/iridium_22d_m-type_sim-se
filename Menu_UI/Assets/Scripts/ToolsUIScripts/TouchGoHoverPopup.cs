using UnityEngine;

public class TouchGoHoverPopup : MonoBehaviour
{
    public GameObject touchGoHoverPopup; 

    private void OnMouseEnter()
    {
        if (touchGoHoverPopup != null)
        {
            touchGoHoverPopup.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (touchGoHoverPopup != null)
        {
            touchGoHoverPopup.SetActive(false);
        }
    }
}
