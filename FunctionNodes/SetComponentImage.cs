using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetComponentImage : Node {

    public SetComponentImage() : base(NodeType.Function) {
        addInputPin(new PinValue()); //Image  
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

        RawImage img = inputPins[0].get();        
        string path = inputPins[1].get();
        

        WWW www = new WWW (path);
        while(!www.isDone)
          return;

        img.texture = www.texture;
        
        Debug.Log("Image Component Set");

        outputPins[0].run();
    }
}