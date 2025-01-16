using UnityEngine;

public class FlagZoom : MonoBehaviour
{
    public Camera mainCamera; 
    public float zoomSpeed = 5f; 
    public float zoomDistance = 10f; 
    public GameObject[] zoneFlags; 

    private Vector3 originalCameraPosition; 
    private bool isZooming = false; 
    private Transform targetFlag; 

    void Start()
    {
        originalCameraPosition = mainCamera.transform.position;
    }

    void Update()
    {
        HandleMouseClick();

        if (isZooming && targetFlag != null)
        {
        }
    }

    private void HandleMouseClick()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                foreach (GameObject zoneFlag in zoneFlags)
                {
                    if (hit.transform.gameObject == zoneFlag)
                    {
                        targetFlag = hit.transform;
                        isZooming = true;
                        return;
                    }
                }
            }
        }
    }

}
