using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneMarker : MonoBehaviour
{
    private GameObject zoneObject; 

    public void SetupZone(GameObject assignedZoneObject)
    {
        zoneObject = assignedZoneObject;
    }

    void OnMouseDown()
    {
        if (zoneObject != null)
        {
            zoneObject.SetActive(true);
            Debug.Log($"Zone '{zoneObject.name}' activated.");
        }
        else
        {
            Debug.LogError("No zone object assigned to this marker.");
        }
    }
}

