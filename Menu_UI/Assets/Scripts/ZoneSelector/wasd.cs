using System.Collections;
using UnityEngine;

public class Wasd : MonoBehaviour
{
    public GameObject wasd;   
    public GameObject updown; 
    private Transform[] wasdSubKeys;
    private Transform[] updownSubKeys;
    private int index = 0;

    void Start()
    {
        if (wasd == null || updown == null)
        {
            return;
        }

        wasdSubKeys = new Transform[wasd.transform.childCount];
        updownSubKeys = new Transform[updown.transform.childCount];

        if (wasdSubKeys.Length != updownSubKeys.Length)
        {
            return;
        }

        for (int i = 0; i < wasdSubKeys.Length; i++)
        {
            wasdSubKeys[i] = wasd.transform.GetChild(i);
        }

        for (int i = 0; i < updownSubKeys.Length; i++)
        {
            updownSubKeys[i] = updown.transform.GetChild(i);
        }

        StartCoroutine(SwitchObjects());
    }

    IEnumerator SwitchObjects()
    {
        while (true)
        {
            if (wasdSubKeys.Length == 0 || updownSubKeys.Length == 0) yield break;
            foreach (Transform child in wasdSubKeys) child.gameObject.SetActive(false);
            foreach (Transform child in updownSubKeys) child.gameObject.SetActive(false);

            randomKey();

            if (index < wasdSubKeys.Length) {
                wasdSubKeys[index].gameObject.SetActive(true);
            }

            if (index < updownSubKeys.Length) {
                updownSubKeys[index].gameObject.SetActive(true);
            }

            yield return new WaitForSeconds(1f); 
        }
    }

    void randomKey() 
    {
        int randomIndex = Random.Range(0, 4);

        if (randomIndex == index) 
        {
            randomKey();
        }

        else 
        {
            index = randomIndex;
        }
    }
}