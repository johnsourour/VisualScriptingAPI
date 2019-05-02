using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakVector : Node {

    public BreakVector() : base(NodeType.Intermediate) {
        addInputPin(new PinValue()); //Vector   
    }

    public bool ready(){
        return inputPins[0].exists();
    }
    
    public override dynamic get(uint pinID){
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return -1;
        }
        
        Vector3 v = inputPins[0].get();

        switch(pinID)
        {
            case 0:
                return v.x;
            case 1:
                return v.y;
            case 2:
                return v.z;
            default:
            {
                Debug.LogError("Invalid pinID at BreakVector");
                return -1;
            }

        }
        
    }

    
}