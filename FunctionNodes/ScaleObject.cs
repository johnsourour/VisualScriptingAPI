using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : Node {
    public ScaleObject() : base(NodeType.Function) {
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

        Vector3 scale = inputPins[0].get();
        GameObject obj = inputPins[1].get();

        // move object
        obj.transform.localScale = scale;
        Debug.Log("Done scaling!");
        
        outputPins[0].run();
    }
}