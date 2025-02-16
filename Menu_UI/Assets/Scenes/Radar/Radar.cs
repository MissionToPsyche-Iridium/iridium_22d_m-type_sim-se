using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public GameObject[] trackedObjects;
    List<GameObject> radarObj;
    public GameObject radarPrefab;
    List<GameObject> borderObjects;
    public float switchDistance;
    public Transform helpTransform;

    // Start is called before the first frame update
    void Start()
    {
        createRadarObjects(); 
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < radarObj.Count; i++)
        {
            if (Vector3.Distance(radarObj[i].transform.position, transform.position) > switchDistance)
            {
                helpTransform.LookAt(radarObj[i].transform);
                borderObjects[i].transform.position = transform.position + switchDistance * helpTransform.forward;
                borderObjects[i].layer = LayerMask.NameToLayer("Radar");
                radarObj[i].layer = LayerMask.NameToLayer("Invisible");
            }
            else
            {
                borderObjects[i].layer = LayerMask.NameToLayer("Invisible");
                radarObj[i].layer = LayerMask.NameToLayer("Radar");
            }
        }
    }
    void createRadarObjects()
    {
        radarObj = new List<GameObject>();
        foreach (GameObject o in radarObj)
        {
            GameObject x = Instantiate(radarPrefab, o.transform.position, Quaternion.identity) as GameObject;
            radarObj.Add(x);
        }
    }
}
