using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetComponentText : Node {

    private TextMesh textComponent;
    public GetComponentText() : base(NodeType.Function) {
        addInputPin(new PinValue()); //Text   
        addOutputPin(new PinExecutable()); //exec out  
    }

    public bool ready(){
        return inputPins[0].exists();
    }
    
    public override void run(){

        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return;
        }

        textComponent = inputPins[0].get();        
        
        
        Debug.Log("Got Text Component");

        outputPins[0].run();
    }

    public override dynamic get(uint pinID){
        return textComponent.text;
    }
}
