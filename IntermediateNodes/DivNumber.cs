using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivNumber : Node {

    public DivNumber() : base(NodeType.Intermediate) {
        addInputPin(new PinValue()); //int
        addInputPin(new PinValue()); //int   
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
        float z = x / y;
        
        Debug.Log("Ints divided");

        return z;
        
    }

    
}