using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcatenateString : Node {

    public ConcatenateString() : base(NodeType.Intermediate) {
        addInputPin(new PinValue()); //string
        addInputPin(new PinValue()); //string  
    }

    public bool ready(){
        return inputPins[0].exists() && inputPins[1].exists();
    }
    
    public override dynamic get(uint pinID){
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return -1;
        }

        string x = inputPins[0].get();
        string y = inputPins[1].get();
        string z = string.Concat(x,y);
        
        Debug.Log("Strings concatenated");

        return z;
        
    }

    
}