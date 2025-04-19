using UnityEngine;

public class CloseInstructionScreen : MonoBehaviour
{
    public GameObject instructionGroupPanels;

    public void CloseScreen() 
    {
        Debug.Log("CloseScreen() was called");
        instructionGroupPanels.SetActive(false);
    }
}