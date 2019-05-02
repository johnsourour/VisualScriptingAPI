using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNumber : Node {

    public AddNumber() : base(NodeType.Intermediate) {
        addInputPin(new PinValue()); //float
        addInputPin(new PinValue()); //float   
    }

    public bool ready(){
        return inputPins[0].exists() && inputPins[1].exists();
    }
    
    public override dynamic get(uint pinID){
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return -1;
        }

        float x = inputPins[0].get();
        float y = inputPins[1].get();
        float z = x + y;
        
        Debug.Log("Numbers Added");

        return z;
        
    }

    
}