using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class character : MonoBehaviour
{
    private ChangeTool changeTools;
    private CharacterController characterController;
    private Animator animator;
    public Animator clawAnimator;
    public Animator screwAnimator;
    public float robotSpeed = 6;
    public float rotationSpeed = 1000f; // turning speed of robot
    public float gravity = -0.144f;     // gravity on 16 Psyche
    private float currentRotationAngle = 0f;
    private Vector3 velocity;
    public float interactionRange = 5f;
    public ShowIncorrectToolPanel showIncorrectToolPanel;
    public int sampleCount;
    public UpdateSamplePanel updateSamplePanel;
    public TouchAndGo_Activation tng;
    public GameObject globalSampleDetectWindow;



    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        changeTools = GetComponent<ChangeTool>();
    }

    void Update()
    {
        CheckForSampleInteraction("SampleChimra", changeTools.chimraTool, "Chimra");
        CheckForTNGSampleInteraction("SampleTNG", changeTools.touchTool, "TNG");
        CheckForSampleInteraction("SampleScrew", changeTools.archScrew, "Arch Screw");
        CheckForSampleInteraction("SampleClaw", changeTools.clawTool, "Claw");

        // WASD movements
        float horizontal = Input.GetAxis("Horizontal");  // left and right arrow keys or A/D
        float vertical = Input.GetAxis("Vertical");     // forward and arrow keys or W/S

        //Debug.Log(vertical);
        if (horizontal != 0)
        {
            animator.SetFloat("Horizontal", horizontal * robotSpeed);
            currentRotationAngle += horizontal * rotationSpeed * Time.deltaTime;
            currentRotationAngle = Mathf.Repeat(currentRotationAngle, 360);
            transform.rotation = Quaternion.Euler(0, currentRotationAngle, 0);
            animator.SetFloat("Horizontal", horizontal * robotSpeed);
        }

        animator.SetFloat("Vertical", vertical * robotSpeed);
        Vector3 move = transform.forward * vertical;  // forward 

        if (!characterController.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = -2f;
        }

        characterController.Move(move * robotSpeed * Time.deltaTime + velocity * Time.deltaTime);
    }

    private void CheckForSampleInteraction(string requiredTag, GameObject currentTool, string toolName)
    {
        if (!currentTool.activeSelf) return;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactionRange);
        bool isCorrectTool = false;
        bool sampleNearby = false;
        string correctToolName = "";

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("SampleChimra") || hitCollider.CompareTag("SampleTNG") ||
                hitCollider.CompareTag("SampleScrew") || hitCollider.CompareTag("SampleClaw"))
            {
                sampleNearby = true;
                clawAnimator.ResetTrigger("Sampling");
                screwAnimator.ResetTrigger("Sampling");

                if (hitCollider.CompareTag(requiredTag))
                {
                    isCorrectTool = true;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        clawAnimator.SetTrigger("Sampling");
                        screwAnimator.SetTrigger("Sampling");
                        GameObject.Find("SamplingDust").GetComponent<ParticleSystem>().Play();
                        InteractWithRock(hitCollider.gameObject);
                        sampleCount++;
                        updateSamplePanel.UpdateSampleCollection();
                    }
                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    switch (hitCollider.tag)
                    {
                        case "SampleChimra": correctToolName = "Chimra"; break;
                        case "SampleTNG": correctToolName = "TNG"; break;
                        case "SampleScrew": correctToolName = "Arch Screw"; break;
                        case "SampleClaw": correctToolName = "Claw"; break;
                    }

                    if (showIncorrectToolPanel != null && correctToolName != "")
                    {
                        showIncorrectToolPanel.ShowPanel(2f, correctToolName);
                    }
                }
            }
        }

        if (!sampleNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (showIncorrectToolPanel != null)
            {
                //showIncorrectToolPanel.ShowPanel(2f, toolName);
            }
        }
    }

    private void CheckForTNGSampleInteraction(string requiredTag, GameObject currentTool, string toolName)
    {
        if (!currentTool.activeSelf) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Collider[] hitColliders;

        if (Physics.Raycast(ray, out hit))
        {
            hitColliders = Physics.OverlapSphere(hit.point, interactionRange);

            bool isCorrectTool = false;
            string correctToolName = "";

            foreach (Collider hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("SampleChimra") || hitCollider.CompareTag("SampleTNG") ||
                    hitCollider.CompareTag("SampleScrew") || hitCollider.CompareTag("SampleClaw"))
                {

                    if (hitCollider.CompareTag(requiredTag))
                    {
                        isCorrectTool = true;

                        if (Input.GetKeyDown(KeyCode.E) && !tng.isAnimating)
                        {

                            if (hit.collider == hitCollider)
                            {
                                
                                tng.setRock(hitCollider.gameObject);
                                sampleCount++;
                                updateSamplePanel.UpdateSampleCollection();
                            }
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.E))
                    {
                        switch (hitCollider.tag)
                        {
                            case "SampleChimra": correctToolName = "Chimra"; break;
                            case "SampleTNG": correctToolName = "TNG"; break;
                            case "SampleScrew": correctToolName = "Arch Screw"; break;
                            case "SampleClaw": correctToolName = "Claw"; break;
                        }

                        if (showIncorrectToolPanel != null && correctToolName != "")
                        {
                            showIncorrectToolPanel.ShowPanel(2f, correctToolName);
                        }
                    }
                }
            }
        }
    }

    private void InteractWithRock(GameObject rock)
    {
        Debug.Log("Interacting with: " + rock.name);

        Transform pressEText = rock.transform.Find("PressEText");
        if (pressEText != null)
        {
            pressEText.gameObject.SetActive(false);
        }

        if (globalSampleDetectWindow != null)
        {
            globalSampleDetectWindow.SetActive(false);
        }

        SampleRange rockSample = rock.GetComponent<SampleRange>();
        if (rockSample != null)
        {
            rockSample.MarkCollected();
        }

        rock.SetActive(false);

    }

    public int getSampleCount()
    {
        return sampleCount;
    }
}