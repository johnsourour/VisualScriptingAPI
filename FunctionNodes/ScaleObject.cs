using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : Node {
    public ScaleObject() : base(NodeType.Function) {
        addInputPin(new PinValue()); //Scale
        addInputPin(new PinValue()); //object
        addOutputPin(new PinExecutable()); //execution out
    }

    public void setScalePin(Node src, PinDataType type){
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

        Vector3 scale = inputPins[0].get();
        Transform obj = inputPins[1].get();

        // move object
        obj.localScale = scale;
        Debug.Log("Done scaling!");
        
        outputPins[0].run();
    }
}