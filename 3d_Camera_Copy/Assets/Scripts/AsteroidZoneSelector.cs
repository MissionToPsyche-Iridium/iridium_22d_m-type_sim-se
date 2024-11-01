using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidZoneSelector : MonoBehaviour
{
    public GameObject dotPrefab;  // Prefab for the clickable dot
    public Transform[] zonePositions;  // Positions for each zone marker
    public string[] zoneSceneNames;  // Scene names for each zone

    void Start()
    {
        PlaceZoneMarkers();
    }

    // Place zone markers on the asteroid surface
    void PlaceZoneMarkers()
    {
        for (int i = 0; i < zonePositions.Length; i++)
        {
            Transform zonePosition = zonePositions[i];
            GameObject dot = Instantiate(dotPrefab, zonePosition.position, Quaternion.identity);
            dot.transform.SetParent(transform);  // Attach to asteroid

            // Add ZoneMarker component and set it up with index
            ZoneMarker zoneMarker = dot.AddComponent<ZoneMarker>();
            zoneMarker.SetupZone(this, i);
        }
    }

    // Load the selected zone scene
    public void LoadZone(int zoneIndex)
    {
        if (zoneIndex >= 0 && zoneIndex < zoneSceneNames.Length)
        {
            string sceneName = zoneSceneNames[zoneIndex];
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);  // Load the selected scene
            Debug.Log($"Scene '{sceneName}' loaded.");
        }
        else
        {
            Debug.LogError("Zone index out of range or scene name not set!");
        }
    }
}


