using UnityEngine;

public class playBeaconAnimation : MonoBehaviour
{
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        animator.Play("BeaconSpin");
    }
}
