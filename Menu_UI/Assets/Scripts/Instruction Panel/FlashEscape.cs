using UnityEngine;
using System.Collections;

public class FlashEscape : MonoBehaviour
{
    public GameObject unpressedEscape;
    public GameObject pressedEscape;
    public float switchInterval = 0.5f;

    private void Start()
    {
        StartCoroutine(SwitchImages());
    }

    IEnumerator SwitchImages()
    {
        while (true)
        {
            unpressedEscape.SetActive(true);
            pressedEscape.SetActive(false);
            yield return new WaitForSeconds(switchInterval);

            unpressedEscape.SetActive(false);
            pressedEscape.SetActive(true);
            yield return new WaitForSeconds(switchInterval);
        }
    }
}