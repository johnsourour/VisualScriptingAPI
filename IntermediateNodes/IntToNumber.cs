using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntToNumber : Node {

    public IntToNumber() : base(NodeType.Intermediate) {
        addInputPin(new PinValue()); //int  
    }

    public bool ready(){
        return inputPins[0].exists();
    }
    
    public override dynamic get(uint pinID){
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return -1;
        }

        float x = (int)(float)inputPins[0].get();
        
        return x;
        
    }

    
}