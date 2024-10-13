using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public float forwardSpeed;
    public float backwardSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        // flap
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
        }

        // forward
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = Vector2.right * forwardSpeed;
            transform.rotation = Quaternion.Euler(0, 0, -30);
        }

        // backward
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = Vector2.left * backwardSpeed;
            transform.rotation = Quaternion.Euler(0, 0, 30);
        }
    }
}
