using UnityEngine;
using System.Collections;

public class FlashWASD : MonoBehaviour
{
    public GameObject unpressedWASD;
    public GameObject pressedWASD;
    public float switchInterval = 0.5f;

    private void Start()
    {
        StartCoroutine(SwitchImages());
    }

    IEnumerator SwitchImages()
    {
        while (true)
        {
            unpressedWASD.SetActive(true);
            pressedWASD.SetActive(false);
            yield return new WaitForSeconds(switchInterval);

            unpressedWASD.SetActive(false);
            pressedWASD.SetActive(true);
            yield return new WaitForSeconds(switchInterval);
        }
    }
}