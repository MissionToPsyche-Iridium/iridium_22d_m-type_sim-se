using UnityEngine;

public class CloseInstructionScreen : MonoBehaviour
{
    public GameObject instructionScreen;

    public void CloseScreen() 
    {
        instructionScreen.SetActive(false);
    }
}