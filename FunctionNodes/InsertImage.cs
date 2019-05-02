using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertImage : Node {
    public InsertImage() : base(NodeType.Function) {
        addInputPin(new PinValue()); //Image
        addInputPin(new PinValue()); //Vector
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

       // Image img = inputPins[0].get();
        Vector3 pos = inputPins[1].get();
        

        // insert image ???
        
        outputPins[0].run();
    }
}