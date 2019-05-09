using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberToString : Node {

    public NumberToString() : base(NodeType.Intermediate) {
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

        float v = (float)inputPins[0].get();
        string x = v.ToString();

        return x;
        
    }

    
}