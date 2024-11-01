using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneMarker : MonoBehaviour
{
    private AsteroidZoneSelector zoneSelector;
    private int zoneIndex;

    // Setup function to initialize the marker with a reference to the AsteroidZoneSelector
    public void SetupZone(AsteroidZoneSelector selector, int index)
    {
        zoneSelector = selector;
        zoneIndex = index;
    }

    void OnMouseDown()
    {
        if (zoneSelector != null)
        {
            zoneSelector.LoadZone(zoneIndex);  // Trigger the scene load for the zone
        }
    }
}

