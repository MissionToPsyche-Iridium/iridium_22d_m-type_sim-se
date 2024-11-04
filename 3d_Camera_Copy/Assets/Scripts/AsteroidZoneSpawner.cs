using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidZoneSpawner : MonoBehaviour
{
    public GameObject spherePrefab;  
    public Transform[] spherePositions;  
    public GameObject[] zoneObjects;
    private List<GameObject> spawnedSpheres = new List<GameObject>();
    void Start()
    {
        SpawnZoneMarkers();
    }

    void SpawnZoneMarkers()
    {
        for (int i = 0; i < spherePositions.Length; i++)
        {
            GameObject sphere = Instantiate(spherePrefab, spherePositions[i].position, Quaternion.identity);
            sphere.transform.SetParent(transform);  

            
            ZoneMarker zoneMarker = sphere.AddComponent<ZoneMarker>();
            if (i < zoneObjects.Length) 
            {
                zoneMarker.SetupZone(zoneObjects[i]);
            }
            spawnedSpheres.Add(sphere);
        }
    }
    public void RemoveSpheres()
    {
        foreach (GameObject sphere in spawnedSpheres)
        {
            Destroy(sphere);
        }
        spawnedSpheres.Clear();
    }
}
