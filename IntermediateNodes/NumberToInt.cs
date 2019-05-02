using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberToInt : Node {

    public NumberToInt() : base(NodeType.Intermediate) {
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

        int x = (int)inputPins[0].get();
        
        Debug.Log("NumberToInt done");

        return x;
        
    }

    
}