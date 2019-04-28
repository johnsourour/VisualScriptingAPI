using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node {
    public List<PinValue> inputPins;
    public List<PinExecutable> outputPins;
    
    private NodeType type;
    private int nodeID;

    public static int idCount = 0;

    public virtual void run() {
        Debug.LogError("This node does not run.");
    }

    public virtual dynamic get(uint pinID) {
        Debug.LogError("This node does not get values.");
        return null;
    }

    public Node(NodeType t) {
        type    = t;
        nodeID  = idCount++;

        inputPins = new List<PinValue>();
        outputPins = new List<PinExecutable>();
    }
    
    public int getID() {
        return nodeID;
    }

    public NodeType getType() {
        return type;
    }
}