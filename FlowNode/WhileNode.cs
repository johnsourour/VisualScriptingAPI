using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;



public class WhileNode : Node {
    public WhileNode() : base(NodeType.WhileNode) {
        addInputPin(new PinValue());
        addOutputPin(new PinExecutable());
        addOutputPin(new PinExecutable());
        
    }

    public bool ready(){
        return inputPins[0].exists() && outputPins[0].exists() && outputPins[1].exists();
    }

    public bool setConditionPin(Node src, PinDataType type){
        return setInputPin(src, 0, type);
    }

    public bool setWhilePin(Node src){
       return setOutputPin(src, 0);
    }

    public bool setBreakPin(Node src){
       return setOutputPin(src, 1);
    }

    
    public override void run() {
        if(!ready()){
            Debug.LogError("Node pins not initialized.");
            return;
        }
        dynamic condition;
        condition = inputPins[0].get();
        while(condition){
            outputPins[0].run();
            condition = inputPins[0].get();
        }
            
        outputPins[1].run();
    }
}
