using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSockets : MonoBehaviour
{
    public enum SocketId
    {
        Arm
    }
    Dictionary<SocketId, MeshSocket> socketMap = new Dictionary<SocketId, MeshSocket>();
    // Start is called before the first frame update
    void Start()
    {
        MeshSocket[] sockets = GetComponentsInChildren<MeshSocket>();
        foreach (var socket in sockets)
        {
            socketMap[socket.socketId] = socket;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attach(Transform objectTransform, SocketId socketId)
    {
        socketMap[socketId].Attach(objectTransform);
    }
}
