using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTool : MonoBehaviour
{
    //RoverTool currentTool;
    //Animator animator;
    MeshSockets sockets;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        sockets = GetComponent<MeshSockets>();
        
    }
    /**
    public void changeTool(RoverTool tool)
    {
        currentTool = tool;
        sockets.Attach(tool.transform, MeshSockets.SocketId.Arm);
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
