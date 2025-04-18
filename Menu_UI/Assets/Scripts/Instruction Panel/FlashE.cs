using UnityEngine;
using System.Collections;

public class FlashE : MonoBehaviour
{
    public GameObject unpressedE;
    public GameObject pressedE;
    public float switchInterval = 0.5f;

    private void Start()
    {
        StartCoroutine(SwitchImages());
    }

    IEnumerator SwitchImages()
    {
        while (true)
        {
            unpressedE.SetActive(true);
            pressedE.SetActive(false);
            yield return new WaitForSeconds(switchInterval);

            unpressedE.SetActive(false);
            pressedE.SetActive(true);
            yield return new WaitForSeconds(switchInterval);
        }
    }
}