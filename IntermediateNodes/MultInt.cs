using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultInt : Node {

    public MultInt() : base(NodeType.Intermediate) {
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

        int x = inputPins[0].get();
        int y = inputPins[1].get();
        int z = x * y;
        
        Debug.Log("Ints multiplied");

        return z;
        
    }

    
}