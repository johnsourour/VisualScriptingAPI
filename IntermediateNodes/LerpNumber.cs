using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpNumber : Node {

    public LerpNumber() : base(NodeType.Intermediate) {
        addInputPin(new PinValue()); //float a
        addInputPin(new PinValue()); //float b 
        addInputPin(new PinValue()); //float t   
    }

    public bool ready(){
        return inputPins[0].exists() && inputPins[1].exists() && inputPins[2].exists();
    }
    
    public override dynamic get(uint pinID){
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return -1;
        }
        
        float a = inputPins[0].get();        
        float b = inputPins[1].get();
        float t = inputPins[2].get();

        Debug.Log("Lerp number done");

        return lerp(a, b, t);

        
    }
    private float lerp(float a, float b, float t){
        return (a * (1-t)) + (b * t);
    }

    
}