using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneMarker : MonoBehaviour
{
    private AsteroidZoneSelector zoneSelector;
    public int zoneIndex;

    public void SetupZone(AsteroidZoneSelector selector)
    {
        zoneSelector = selector;
    }

    void OnMouseDown()
    {
        if (zoneSelector != null)
        {
            zoneSelector.LoadZone(zoneIndex);  // Trigger zone loading when clicked
        }
    }
}

