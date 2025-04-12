using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    Transform mainCam;
    Transform rock;
    Transform pressECanvas;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main.transform;
        rock = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (rock == null) return;

        transform.position = rock.position + offset;
        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.position);
    }
}
