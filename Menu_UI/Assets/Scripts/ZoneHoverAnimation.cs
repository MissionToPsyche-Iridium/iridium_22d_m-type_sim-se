using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneHoverAnimation : MonoBehaviour
{
    public Camera mainCamera;
    public Animator animator;
    public float height = 1.0f;

    public void OnMouseEnter()
    {
        Debug.Log("Mouse Detected!");
        animator.SetBool("MouseOver", true);
    }

    public void OnMouseExit()
    {
        Debug.Log("Bye!");
        animator.SetBool("MouseOver", false);
    }
}
