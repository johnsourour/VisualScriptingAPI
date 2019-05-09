using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SquareRoot : Node {

    public SquareRoot() : base(NodeType.Intermediate) {
        addInputPin(new PinValue()); //float
    }

    public bool ready(){
        return inputPins[0].exists();
    }
    
    public override dynamic get(uint pinID){
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return -1;
        }

        float x = inputPins[0].get();
        float z = (float)Math.Sqrt(x);
        Debug.Log("Sqrt done");

        return z;
        
    }

    
}