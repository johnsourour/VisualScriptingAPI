using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Not : Node {

    public Not() : base(NodeType.Intermediate) {
        addInputPin(new PinValue()); //bool
    }

    public bool ready(){
        return inputPins[0].exists();
    }
    
    public override dynamic get(uint pinID){
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return -1;
        }

        bool x = inputPins[0].get();
        bool z = !x;

        return z;
        
    }

    
}