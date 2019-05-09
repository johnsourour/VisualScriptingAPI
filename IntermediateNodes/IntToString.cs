using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntToString : Node {

    public IntToString() : base(NodeType.Intermediate) {
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

        int v = (int)inputPins[0].get();
        string x = v.ToString();

        return x;
        
    }

    
}
