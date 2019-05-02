using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTextComponent : Node {

    private Component comp;
    public CreateTextComponent() : base(NodeType.Function) {
        addInputPin(new PinValue()); //game object      
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

        GameObject obj = inputPins[0].get();
        comp = obj.AddComponent<Text>();

        
        Debug.Log("Text Component Created");
        
        outputPins[0].run();
    }

    public override dynamic get(uint pinID){
        return comp ;
    }
}