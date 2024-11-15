using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTool : MonoBehaviour
{
    public GameObject chimraTool;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (chimraTool.activeSelf == true)
            {
                chimraTool.SetActive(false);
            }
            else
            {
                chimraTool.SetActive(true);
            }
        }
    }
}