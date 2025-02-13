using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public GameObject[] trackedObjects;
    List<GameObject> radarObj;
    public GameObject radarPrefab;

    // Start is called before the first frame update
    void Start()
    {
        createRadarObjects(); 
    }

    // Update is called once per frame
    void Update()
    {
        
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
