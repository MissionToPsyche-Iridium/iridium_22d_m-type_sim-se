using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private Transform mainCam;
    private Transform rock;

    public Vector3 offset = new Vector3(0, 1.5f, 0); 

    void Start()
    {
        mainCam = Camera.main.transform;
        rock = transform.parent;
    }

    void Update()
    {
        if (mainCam == null || rock == null) return;

        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.position);

        transform.position = rock.position + offset;
    }
}
