using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StringLength : Node {

    public StringLength() : base(NodeType.Intermediate) {
        addInputPin(new PinValue()); //string
    }

    public bool ready(){
        return inputPins[0].exists();
    }
    
    public override dynamic get(uint pinID){
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return -1;
        }

        string x = inputPins[0].get();
        int z = x.Length;

        return z;
        
    }

    
}