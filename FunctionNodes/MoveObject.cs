using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : Node {
    public MoveObject() : base(NodeType.Function) {
        addInputPin(new PinValue()); //location
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

        Vector3 location = inputPins[0].get();
        GameObject obj = inputPins[1].get();

        // move object
        obj.transform.position = location;
        Debug.Log("Done moving!");
        
        outputPins[0].run();
    }
}