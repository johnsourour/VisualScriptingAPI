using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeVector : Node {

    public MakeVector() : base(NodeType.Intermediate) {
        addInputPin(new PinValue()); //X 
        addInputPin(new PinValue()); //Y   
        addInputPin(new PinValue()); //Z   
    }

    public bool ready(){
        return inputPins[0].exists() && inputPins[1].exists() && inputPins[2].exists();
    }
    
    public override dynamic get(uint pinID){
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return -1;
        }

        float x = inputPins[0].get();
        float y = inputPins[1].get();
        float z = inputPins[2].get();
        
        Debug.Log("Vector Made");

        return new Vector3(x, y, z);
        
    }

    
}