using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSubstring : Node {

    public GetSubstring() : base(NodeType.Intermediate) {
        addInputPin(new PinValue()); //string
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

        string x = inputPins[0].get();
        int y = inputPins[1].get();
        string z = x.Substring(y);
        
        Debug.Log("Got Substring");

        return z;
        
    }

    
}