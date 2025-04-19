using UnityEngine;
using System.Collections;

public class FlashUpDown : MonoBehaviour
{
    public GameObject unpressedUpDown;
    public GameObject pressedUpDown;
    public float switchInterval = 0.5f;

    //Start
    private void Start()
    {
        StartCoroutine(SwitchImages());
    }

    IEnumerator SwitchImages()
    {
        while (true)
        {
            unpressedUpDown.SetActive(true);
            pressedUpDown.SetActive(false);
            yield return new WaitForSeconds(switchInterval);

            unpressedUpDown.SetActive(false);
            pressedUpDown.SetActive(true);
            yield return new WaitForSeconds(switchInterval);
        }
    }
}