using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidZoneSelector : MonoBehaviour
{
    public GameObject dotPrefab;  
    public Transform[] zonePositions;  // Array to store positions for each zone marker
    private Transform asteroidTransform;

    void Start()
    {
        asteroidTransform = transform; 
        PlaceZoneMarkers();
    }

    // Method to place markers at specified positions
    void PlaceZoneMarkers()
    {
        foreach (Transform zonePosition in zonePositions)
        {
            GameObject dot = Instantiate(dotPrefab, zonePosition.position, Quaternion.identity);
            dot.transform.SetParent(asteroidTransform);  // Ensure dots move with the asteroid
            dot.AddComponent<ZoneMarker>().SetupZone(this);
        }
    }

    // Method to load a zone based on the selected marker
    public void LoadZone(int zoneIndex)
    {
        Debug.Log($"Loading zone {zoneIndex}");
    }
}
