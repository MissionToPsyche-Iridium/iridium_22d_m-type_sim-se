using UnityEngine;

public class DisableToolSelector : MonoBehaviour
{
    public GameObject ToolSelector; 
    public GameObject ToolPopupMenu;

    private void Start()
    {
        if (ToolSelector != null)
        {
            ToolSelector.SetActive(false);
        }

        if (ToolPopupMenu != null)
        {
            ToolPopupMenu.SetActive(false);
        }
    }
}