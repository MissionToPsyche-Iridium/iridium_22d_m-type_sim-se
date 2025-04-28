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
    public bool isAnimating = false;
    Vector3 mousePos;
    Vector3 start;
    Vector3 impact;
    Quaternion startRot;
    Quaternion impactRot;
    Vector3 end;
    Quaternion endRot;
    public ParticleSystem explosion;
    Vector3 flatten;
    Quaternion flatRot;
    Vector3 pointUp;
    Quaternion pointRot;
    GameObject rock;
    GameObject hitObject;


    // Start is called before the first frame update
    void Start()
    {
        mouse = Mouse.current;

        if (button)
        {
            buttonAnimator = button.GetComponent<Animator>();
        }

        if (touchTool)
        {
            explosion.time = 0;
            touchAnimator = touchTool.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (!isAnimating)
            {
                isAnimating = true;
                mousePos = GetMouseWorldPosition();
                GameObject hitObj = GetMouseHitObject();
                if (hitObj != null)
                {
                    SampleRange sr = hitObj.GetComponent<SampleRange>();
                    if (sr != null)
                    {
                        sr.MarkCollected();
                    }

                    hitObject = hitObj;
                }
                if (buttonAnimator != null)
                {
                    buttonAnimator.Play("Base Layer.Button_Press", -1, 0f);
                }

                start = new Vector3(mousePos.x - 50, mousePos.y + 200, mousePos.z - 50);
                //Debug.Log("Start pos: " + start);
                startRot = touch.rotation;

                touch.position = start;

                impact = new Vector3(mousePos.x, mousePos.y + 2.4f, mousePos.z);
                //Debug.Log("impact pos: " + impact);

                impactRot = Quaternion.LookRotation(impact - start);

                end = new Vector3(impact.x + 100, start.y, impact.z + 100);
                //Debug.Log("end pos: " + end);
                endRot = Quaternion.LookRotation(end - impact);

                flatten = new Vector3(impact.x - 10, impact.y, impact.z - 10);
                flatRot = Quaternion.LookRotation(impact - flatten);

                pointUp = new Vector3(flatten.x - 10, flatten.y - 10, flatten.z - 10);
                pointRot = Quaternion.LookRotation(flatten - pointUp);

                touchAnimator.SetBool("open", true);

                StartCoroutine(AnimateMovement(start, impact, startRot, impactRot, () =>
                {
                    explosion.Simulate(0.0f, true, true);
                    explosion.Play();

                    StartCoroutine(AnimateMovement(impact, impact, impactRot, flatRot, () =>
                    {
                        touchAnimator.SetBool("open", false);
                        if (rock)
                        {
                            rock.SetActive(false);
                        }
                        StartCoroutine(AnimateMovement(impact, impact, flatRot, pointRot, () =>
                        {


                            StartCoroutine(AnimateMovement(impact, end, pointRot, endRot, () => { isAnimating = false; }));
                        }));
                    }));
                }, 0.5f));
            }
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }

        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }

    IEnumerator AnimateMovement(Vector3 start, Vector3 end, Quaternion startRot, Quaternion endRot, System.Action onComplete, float delay = 0f)
    {

        float elapsedTime = 0f;
        float t = elapsedTime / animationDuration;

        while (elapsedTime < animationDuration)
        {
            t = elapsedTime / animationDuration;

            touch.position = Vector3.Lerp(start, end, t);
            touch.rotation = Quaternion.Slerp(startRot, endRot, t);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        touch.position = end;
        touch.rotation = endRot;

        if (delay > 0)
        {
            yield return new WaitForSeconds(delay);
        }

        onComplete?.Invoke();
    }

    public void OnEnable()
    {
        /*if (isAnimating) 
        {
            Debug.Log("Object reactivated, restarting animation.");
            StartCoroutine(AnimateMovement(start, impact, startRot, impactRot, () =>
                {
                    
                    StartCoroutine(AnimateMovement(impact, impact, impactRot, flatRot, () =>
                    {
                        touchAnimator.SetBool("open", false);
                        StartCoroutine(AnimateMovement(impact, impact, flatRot, pointRot, () =>
                        {
                            
                            
                            StartCoroutine(AnimateMovement(impact, end, pointRot, endRot, () => { isAnimating = false; }));
                        }));
                    }));
                }, 0.5f));
        }*/
    }

    void OnDisable()
    {
        StopAllCoroutines();
        Vector3 resetPos = new Vector3(0, -500, 0);
        isAnimating = false;
        touch.SetPositionAndRotation(resetPos, endRot);
    }

    public void setRock(GameObject rock)
    {
        this.rock = rock;
    }

    GameObject GetMouseHitObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider.gameObject;
        }

        return null;
    }
}

