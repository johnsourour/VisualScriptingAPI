using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintStringNode : Node {
    public PrintStringNode() : base(NodeType.Function) {
        addInputPin(new PinValue());
        addOutputPin(new PinExecutable());
    }

    public void setStringInputPin(Node src, PinDataType type){
        setInputPin(src,0, type);
    }

    public void setStringOutputPin(Node src){
        setOutputPin(src,0);
    }

    public bool ready(){
        return inputPins[0].exists();
    }
    
    public override void run() {
        if(!ready()){
            Debug.LogError("Node pins not initialized");
            return;
        }

        dynamic val = inputPins[0].get();

        Debug.Log(val as string);
        
        outputPins[0].run();
    }
}