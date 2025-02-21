using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class TouchAndGo_Activation : MonoBehaviour
{

    public GameObject button;
    public GameObject touchTool;
    private Animator buttonAnimator;
    private Animator touchAnimator;
    private Mouse mouse;
    public Transform touch;
    private float animationDuration = 1f;
    private bool isAnimating = false;
    Vector3 mousePos;
    Vector3 start;
    Vector3 end;
    Quaternion startRot;
    Quaternion endRot;
    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        mouse = Mouse.current;
        
        if (button) {
            buttonAnimator = button.GetComponent<Animator>();
        }

        if (touchTool) {
            explosion.time = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (mouse.leftButton.wasPressedThisFrame) {
            mousePos = GetMouseWorldPosition();
            Debug.Log("Button Clicked");

            if (buttonAnimator != null) {
                buttonAnimator.Play("Base Layer.Button_Press", -1, 0f);
            }

            if (!isAnimating) {
                Debug.Log("Start pos: " + mousePos);
                start = new Vector3(mousePos.x - 50, mousePos.y + 200, mousePos.z - 50);
                startRot = touch.rotation;

                touch.position = start;
                
                end = new Vector3(mousePos.x, mousePos.y + 2.4F, mousePos.z);
                Debug.Log("End pos: " + end);

                endRot = Quaternion.LookRotation(end - start);

                isAnimating = true;
                StartCoroutine(AnimateMovement(start, end, startRot, endRot));
            }
        }

        isAnimating = false;
    }

    Vector3 GetMouseWorldPosition() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            return hit.point;
        }
        
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }

IEnumerator AnimateMovement(Vector3 start, Vector3 end, Quaternion startRot, Quaternion endRot) {
        float elapsedTime = 0f;
        float t = elapsedTime / animationDuration;

        while (elapsedTime < animationDuration) {
            t = elapsedTime / animationDuration;

            touch.position = Vector3.Lerp(start, end, t);
            touch.rotation = Quaternion.Slerp(startRot, endRot, t);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        touch.position = end;
        touch.rotation = endRot;
        explosion.Simulate(0.0f, true, true);
        explosion.Play();
    }

}
