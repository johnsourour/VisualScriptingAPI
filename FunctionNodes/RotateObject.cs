using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : Node {
    public RotateObject() : base(NodeType.Function) {
        addInputPin(new PinValue()); //Scale
        addInputPin(new PinValue()); //object
        addOutputPin(new PinExecutable()); //execution out
    }

    public bool ready(){
        return inputPins[0].exists() && inputPins[1].exists();
    }
    
    public override void run() {
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return;
        }

        Vector3 rotation = inputPins[0].get();
        Transform obj = inputPins[1].get();

        // move object
        obj.Rotate(rotation);
        Debug.Log("Done rotating!");
        
        outputPins[0].run();
    }
}