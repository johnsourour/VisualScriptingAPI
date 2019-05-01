using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTextComponent : Node {

    public GetTextComponent() : base(NodeType.Intermediate) {
        addInputPin(new PinValue()); //game object      
    }

    public bool ready(){
        return inputPins[0].exists();
    }
    
    public override dynamic get(uint pinID){
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return;
        }

        GameObject? obj = inputPins[0].get();
        return obj;
    }

    
}