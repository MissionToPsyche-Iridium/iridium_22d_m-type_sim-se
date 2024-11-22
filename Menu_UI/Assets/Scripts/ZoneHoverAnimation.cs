using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneHoverAnimation : MonoBehaviour
{
    public Animator animator;

    public void OnMouseEnter()
    {
        animator.SetBool("MouseOver", true);
    }
    
    public void OnMouseExit()
    {
        animator.SetBool("MouseOver", false);
    }
}
