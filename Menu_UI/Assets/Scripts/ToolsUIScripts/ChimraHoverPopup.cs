using UnityEngine;

public class ChimraHoverPopup : MonoBehaviour
{
    public GameObject chimraHoverPopup; 

    private void OnMouseEnter()
    {
        if (chimraHoverPopup != null)
        {
            chimraHoverPopup.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (chimraHoverPopup != null)
        {
            chimraHoverPopup.SetActive(false);
        }
    }
}
