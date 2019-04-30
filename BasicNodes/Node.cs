using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node {
    protected List<PinValue> inputPins;
    protected List<PinExecutable> outputPins;
    
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

    protected void addInputPin(PinValue p){
        inputPins.Add(p);
    }

    protected bool setInputPin(Node src, uint pinID, PinDataType typ){
        if(pinID >= inputPins.Count){
            Debug.LogError("Invalid pinID.");
            return false;
        }
        inputPins[(int)pinID] = new PinValue(src, pinID, typ);
        return true;

    }

    protected void addOutputPin(PinExecutable p){
        outputPins.Add(p);
        setOutputPin(null,(uint)outputPins.Count-1);
    }

    protected bool setOutputPin(Node src, uint pinID){
        if(pinID >= outputPins.Count){
            Debug.LogError("Invalid pinID.");
            return false;
        }
        outputPins[(int)pinID] = new PinExecutable(src, pinID);
        return true;

    }

    public PinValue getInputPin(int pinID){
        if(pinID >= inputPins.Count){
            Debug.LogError("Invalid pinID.");
            return new PinValue();
        }
        return inputPins[pinID];
    }

    public PinExecutable getOutputPin(int pinID){
        if(pinID >= outputPins.Count){
            Debug.LogError("Invalid pinID.");
            return new PinExecutable();
        }
        return outputPins[pinID];
    }
    
    public int getID() {
        return nodeID;
    }
    public NodeType getType() {
        return type;
    }
}