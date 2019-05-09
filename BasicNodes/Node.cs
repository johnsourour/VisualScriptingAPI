using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node {
    protected List<PinValue> inputPins;
    protected List<PinExecutable> outputPins;
    
    public ScriptContainer scriptContainer;
    private NodeType type;
    private int nodeID;
    public string displayname;
    public string internalname;

    public static int idCount = 0;

    public virtual void run() {
        Debug.LogError(internalname + " node does not run.");
    }

    public virtual dynamic get(uint pinID) {
        Debug.LogError(internalname + " node does not get values.");
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

    public bool setInputPin(int srcID, Node src, uint pinID, PinDataType typ){
        if(pinID >= inputPins.Count){
            Debug.LogError("Invalid pinID.");
            return false;
        }
        inputPins[(int)pinID] = new PinValue(src, pinID, typ);
        return true;
    }

    public bool setInputPin(int srcID, uint nodeID, uint pinID, PinDataType typ){
        if(srcID >= inputPins.Count){
            Debug.LogError("In node " + nodeID +  " adding a pin at an invalid ID: " + srcID);
            return false;
        }
        inputPins[srcID] = new PinValue(nodeID, pinID, typ);
        return true;
    }

    protected void addOutputPin(PinExecutable p){
        outputPins.Add(p);
        //setOutputPin(null,(uint)outputPins.Count-1);
    }

    public bool setOutputPin(int srcPin, Node src, uint pinID){
        if(srcPin >= outputPins.Count){
            Debug.LogError("Invalid pinID.");
            return false;
        }
        outputPins[srcPin] = new PinExecutable(src, pinID);
        return true;

    }

    public bool setOutputPin(int srcPin, uint nodeID, uint pinID){
        outputPins[srcPin] = new PinExecutable(nodeID, pinID);
        return true;
    }

    public void setPinValues() {
        foreach (PinValue item in inputPins) {
            uint n = item.source.nodeID;
            item.source.source = scriptContainer.nodes[(int)n];
        }
        
        foreach (PinExecutable item in outputPins) {
            if (item.source != null) {
                uint n = item.source.nodeID;
                item.source.source = scriptContainer.nodes[(int)n];
            }
        }
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
            Debug.LogError("Invalid pinID: " + pinID);
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