using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : Node {
    public MoveObject() : base(NodeType.Function) {
        addInputPin(new PinValue()); //location
        addInputPin(new PinValue()); //object
        addOutputPin(new PinExecutable()); //execution out
       
    }

    public void setLocationPin(Node src, PinDataType type){
        setInputPin(src, 0, type);
    }

    public void setObjectPin(Node src, PinDataType type){
        setInputPin(src, 1, type);
    }

    public void setExecOutputPin(Node src){
        setOutputPin(src,0);
    }

    public bool ready(){
        return inputPins[0].exists() && inputPins[1].exists();
    }
    
    public override void run() {
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return;
        }

        Vector3 location = inputPins[0].get();
        Transform obj = inputPins[1].get();

        // move object
        obj.position = location;
        Debug.Log("Done moving!");
        
        outputPins[0].run();
    }
}