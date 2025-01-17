using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetComponentText : Node {

    public SetComponentText() : base(NodeType.Function) {
        addInputPin(new PinValue()); //Text   
        addInputPin(new PinValue()); //string 
        addOutputPin(new PinExecutable()); //exec out  
    }

    public bool ready(){
        return inputPins[0].exists() && inputPins[1].exists();
    }
    
    public override void run(){

        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return;
        }

        TextMesh textComponent = inputPins[0].get();        
        string str = inputPins[1].get();
        
        textComponent.text = str;
        
        Debug.Log("Text Component Set");

        outputPins[0].run();
    }
}
