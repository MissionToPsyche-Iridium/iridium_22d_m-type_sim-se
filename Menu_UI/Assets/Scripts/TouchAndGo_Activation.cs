using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchAndGo_Activation : MonoBehaviour
{

    public GameObject button;
    public GameObject touchTool;
    private Animator buttonAnimator;
    private Mouse mouse;

    // Start is called before the first frame update
    void Start()
    {
        mouse = Mouse.current;
        touchTool = null;
        if (button) {
            buttonAnimator = button.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if (mouse.leftButton.wasPressedThisFrame) {
            Debug.Log("Button Clicked");
            if (buttonAnimator != null) {
                buttonAnimator.Play("Base Layer.Button_Press", -1, 0f);
            }
        }
    }

}
