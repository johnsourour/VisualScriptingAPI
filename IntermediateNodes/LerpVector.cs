using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpVector : Node {

    public LerpVector() : base(NodeType.Intermediate) {
        addInputPin(new PinValue()); //Vector a
        addInputPin(new PinValue()); //Vector b 
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
        
        Vector3 a = inputPins[0].get();        
        Vector3 b = inputPins[1].get();
        float t = inputPins[2].get();
        
        float x = lerp(a.x, b.x, t);
        float y = lerp(a.y, b.y, t);
        float z = lerp(a.z, b.z, t);

        Debug.Log("Lerp vector done");
        return new Vector3(x, y, z);

        
    }
    private float lerp(float a, float b, float t){
        return (a * (1-t)) + (b * t);
    }

    
}